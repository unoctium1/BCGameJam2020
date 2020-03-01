using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthAdjustment : MonoBehaviour {
	
	public void SetDepth(float depth)
	{
		if (depth < 0) depth = 0;
		Vector3 pos = transform.localPosition;
		pos.z = -depth;
		transform.localPosition = pos;
	}
}
