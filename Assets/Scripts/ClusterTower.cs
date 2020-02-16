using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterTower : TowerBehavior
{
	[SerializeField, Range(1f, 100f)]
	float damagePerSecond = 10f;

	//[SerializeField]
	//TargetPoint target;

	[SerializeField]
	LineRenderer[] lines = default;

    TargetPoint[] points = new TargetPoint[100];
	

	public override void TowerUpdate()
	{
        points = TargetPoint.AllTargets(transform.position, 100f);
        int k = 0;
        foreach(var x in points)
        {
            TargetPoint temp = x;
            if (TrackTarget(ref temp) || AcquireTarget(out temp))
            {
                if (IsFiring)
                {
                    Shoot(k,temp);
                    k++;
                }
                else
                {
                    lines[k].enabled = false;
                }
            }
            else
            {
                lines[k].enabled = false;
            }
        }
        
	}

	void Shoot(int k,TargetPoint x)
	{
		lines[k].enabled = true;
		Vector3 point = x.Position;
		lines[k].SetPosition(0, this.transform.position);
		lines[k].SetPosition(1, point);
        x.Enemy.ApplyDamage(damagePerSecond * Time.deltaTime);
	}
}
