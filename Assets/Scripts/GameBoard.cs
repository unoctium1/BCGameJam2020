using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

	[SerializeField]
	Transform ground = default(Transform);

	int size;

	public void Initialize(int size)
	{
		this.size = size;
		ground.localScale = new Vector3(size, size, 1f);


	}

}
