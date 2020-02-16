using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBehavior : MonoBehaviour
{
    [SerializeField, Range(1.5f, 10.5f)]
    protected float targetingRange = 1.5f;

	protected bool AcquireTarget(out TargetPoint target)
	{
		if (TargetPoint.FillBuffer(transform.localPosition, targetingRange))
		{
			target = TargetPoint.RandomBuffered;
			return true;
		}
		target = null;
		return false;
	}

	protected bool TrackTarget(ref TargetPoint target)
	{
		if (target == null || !target.Enemy.IsValid)
		{
			return false;
		}

		Vector2 a = transform.localPosition;
		Vector2 b = target.Position;
		if (Vector2.Distance(a, b) > targetingRange + 0.125f)
		{
			target = null;
			return false;
		}
		return true;
	}

	public abstract void TowerUpdate();

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.yellow;
		Vector2 position = transform.localPosition;
		Gizmos.DrawWireSphere(position, targetingRange);
	}
}
