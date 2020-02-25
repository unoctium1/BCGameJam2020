/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeTower : TowerBehavior
{
	[SerializeField, Range(1f, 200f)]
	float damagePerSecond = 5f;

	[SerializeField]
	TargetPoint target;

	[SerializeField]
	private LineRenderer line = default;

	

	public override void TowerUpdate()
	{
		if (TrackTarget(ref target) || AcquireTarget(out target))
		{
			if(IsFiring)
				Shoot();
			else
			{
				line.enabled = false;
			}
		}
		else
		{
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
	}
}
*/
