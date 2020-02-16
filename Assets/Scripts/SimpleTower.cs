using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTower : TowerBehavior
{
	[SerializeField, Range(1f, 100f)]
	float damagePerSecond = 10f;
	[SerializeField]
	TargetPoint target;

	[SerializeField]
	private LineRenderer line = default;

	public override void TowerUpdate()
	{
		if (TrackTarget(ref target) || AcquireTarget(out target))
		{
			Debug.Log("Gotcha");
			Shoot();
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
		line.SetPosition(1, point);
		target.Enemy.ApplyDamage(damagePerSecond * Time.deltaTime);
	}
}
