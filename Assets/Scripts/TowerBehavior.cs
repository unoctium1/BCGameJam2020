using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    [SerializeField, Range(1.5f, 10.5f)]
    float targetingRange = 1.5f;

    [SerializeField]
    private float damage;

	[SerializeField]
	private int maxHits = 50;

	TargetPoint target;
	Collider2D[] buffer;

	const int enemyLayerMask = 1 << 8;



	public void Update()
	{
		if (TrackTarget() || AcquireTarget())
		{
			Debug.Log("Acquired target!");
		}
	}

	bool AcquireTarget()
	{
		int hits = Physics2D.OverlapCircleNonAlloc(transform.position, targetingRange, buffer, enemyLayerMask);
		if (hits > 0)
		{
			target = buffer[0].GetComponent<TargetPoint>();
			Debug.Assert(target != null, "Targeted non-enemy!", buffer[0]);
			return true;
		}
		target = null;
		return false;
	}

	bool TrackTarget()
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

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.yellow;
		Vector3 position = transform.localPosition;
		Gizmos.DrawWireSphere(position, targetingRange);
		if (target != null)
		{
			Gizmos.DrawLine(position, target.Position);
		}
	}
}
