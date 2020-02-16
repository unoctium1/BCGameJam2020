using UnityEngine;

public class TargetPoint : MonoBehaviour
{

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
