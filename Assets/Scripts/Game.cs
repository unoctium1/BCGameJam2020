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

    [SerializeField]
    ButtonBehavior[] buttonBehaviors;




    List<WayPointWalker> walkers = new List<WayPointWalker>();

	List<TowerBehavior> towers = new List<TowerBehavior>();

	[SerializeField]
	float spawnSpeed = 3f;

	float spawnProgress = 0.0f;

	bool isEnemyWavePhase = true;

	private WayPointWalker GetRandomWalker()
	{
		StartPoint s = startPoints[Random.Range(0, startPoints.Length)];
		WayPointWalker w = enemyFactory.GetRandom();
		w.Initialize(s);
		return w;

	}

    private void Start()
    {
        
    }

    private void Update()
	{
        if (isEnemyWavePhase)
		{
			Phase2Update();
		}
		else
		{
			Phase1Update();
		}

	}

	private void Phase1Update()
	{

	}

	private void Phase2Update()
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
        Physics2D.SyncTransforms();

        for (int i = 0; i < towers.Count; i++)
        {
            towers[i].TowerUpdate();
        }

        #region Sound when its individual (commented)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            buttonBehaviors[0].TowerSpaceFires();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            buttonBehaviors[1].TowerSpaceFires();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            buttonBehaviors[2].TowerSpaceFires();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            buttonBehaviors[3].TowerSpaceFires();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            buttonBehaviors[4].TowerSpaceFires();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            buttonBehaviors[5].TowerSpaceFires();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            buttonBehaviors[6].TowerSpaceFires();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            buttonBehaviors[7].TowerSpaceFires();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            buttonBehaviors[8].TowerSpaceFires();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            buttonBehaviors[9].TowerSpaceFires();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            buttonBehaviors[10].TowerSpaceFires();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            buttonBehaviors[11].TowerSpaceFires();
        }
        #endregion

    }

		
}
