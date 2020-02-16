using UnityEngine;

public class TargetPoint : MonoBehaviour
{
	const int enemyLayerMask = 1 << 8;

	static Collider2D[] buffer = new Collider2D[100];

	public static int BufferedCount { get; private set; }

	public static TargetPoint RandomBuffered =>
		GetBuffered(Random.Range(0, BufferedCount));

	public static bool FillBuffer(Vector2 position, float range)
	{
		BufferedCount = Physics2D.OverlapCircleNonAlloc(
			position, range, buffer, enemyLayerMask
		);
		return BufferedCount > 0;
	}

	public static TargetPoint GetBuffered(int index)
	{
		var target = buffer[index].GetComponent<TargetPoint>();
		Debug.Assert(target != null, "Targeted non-enemy!", buffer[0]);
		return target;
	}
	public WayPointWalker Enemy { get; private set; }

	public Vector3 Position => transform.position;

	void Awake()
	{
		Enemy = transform.root.GetComponent<WayPointWalker>();
		Debug.Assert(Enemy != null, "Target point without Enemy root!", this);
		Debug.Assert(
			GetComponent<BoxCollider2D>() != null,
			"Target point without collider!", this
		);
		Debug.Assert(gameObject.layer == 8, "Target point on wrong layer!", this);
	}


}
