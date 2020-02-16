using UnityEngine;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
	[SerializeField]
	StartPoint[] startPoints;
	[SerializeField]
	EndPoint[] endPoints;

	[SerializeField]
	EnemyFactory enemyFactory;

	List<WayPointWalker> walkers = new List<WayPointWalker>();

	[SerializeField]
	float spawnSpeed = 3f;

	float spawnProgress = 0.0f;

	bool isEnemyWavePhase = false;

	private WayPointWalker GetRandomWalker()
	{
		StartPoint s = startPoints[Random.Range(0, startPoints.Length)];
		WayPointWalker w = enemyFactory.GetRandom();
		w.Initialize(s);
		return w;

	}

	private void Update()
	{
		if (isEnemyWavePhase)
		{
			spawnProgress += spawnSpeed * Time.deltaTime;
			while (spawnProgress >= 1f)
			{
				spawnProgress -= 1f;
				walkers.Add(GetRandomWalker());
			}

			for (int i = 0; i < walkers.Count; i++)
			{
				if (!walkers[i].UpdateWalker())
				{
					int lastIndex = walkers.Count - 1;
					WayPointWalker toDelete = walkers[i];
					walkers[i] = walkers[lastIndex];
					walkers.RemoveAt(lastIndex);
					i -= 1;
					toDelete.EndBehavior();
				}
			}
		}

	}
}
