using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class EnemyFactory : GameObjectFactory

{
    [SerializeField]
    WayPointWalker[] prefabs;

	List<WayPointWalker>[] pools;

	void CreatePools()
	{
		pools = new List<WayPointWalker>[prefabs.Length];
		for (int i = 0; i < pools.Length; i++)
		{
			pools[i] = new List<WayPointWalker>();
		}
	}

	public WayPointWalker Get(int id)
	{
		WayPointWalker instance;
		if (pools == null)
		{
			CreatePools();
		}
		List<WayPointWalker> pool = pools[id];
		int index = pool.Count - 1;
		if(index >= 0)
		{
			instance = pool[index];
			pool.RemoveAt(index);
		}
		else
		{
			instance = CreateGameObjectInstance(prefabs[id]);
			instance.Id = id;
			instance.OriginFactory = this;
		}
		return instance;
	}

	public WayPointWalker GetRandom()
	{
		return Get(Random.Range(0, prefabs.Length));
	}

	public void Reclaim(WayPointWalker enemy)
	{
		Debug.Assert(enemy.OriginFactory == this, "Wrong factory reclaimed!");
		if(pools == null)
		{
			CreatePools();
		}
		pools[enemy.Id].Add(enemy);
		enemy.gameObject.SetActive(false);
	}
}
