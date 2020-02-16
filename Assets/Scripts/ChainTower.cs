using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainTower : TowerBehavior
{
	[SerializeField, Range(1f, 100f)]
	float damagePerSecond = 10f;

	[SerializeField]
	TargetPoint target;

    [SerializeField]
    TargetPoint target2;

	[SerializeField]
	private LineRenderer line = default;
	[SerializeField]
	private LineRenderer line2 = default;

	private void OnEnable()
	{
		line.enabled = false;
		line2.enabled = false;
	}

	public override void TowerUpdate()
	{
		if (TrackTarget(ref target) || AcquireTarget(out target))
		{
			if(IsFiring)
				Shoot();
			else
			{
                line2.enabled = false;
				line.enabled = false;
			}
		}
		else
		{
            line2.enabled = false;
			line.enabled = false;
		}
	}

	void Shoot()
	{
		line.enabled = true;
		Vector3 point = target.Position;
		line.SetPosition(0, this.transform.position);
		line.SetPosition(1, point);
		target.Enemy.ApplyDamage(damagePerSecond * Time.deltaTime);

        //Trying for a second shoot
        if (TargetPoint.FillBuffer(point, targetingRange))
        {
            if (!(target2 == null || !target2.Enemy.IsValid))
            {
                target2 = TargetPoint.RandomBuffered;
                line2.enabled = true;
                Vector2 a = point;
                Vector2 b = target2.Position;
                if (Vector2.Distance(a, b) > targetingRange + 0.125f)
                {
                    target2 = null;
                }
                else
                {
                    line2.SetPosition(0, point);
                    line2.SetPosition(1, target2.Position);
                }
                
            }
            
        }

        
    }
}
