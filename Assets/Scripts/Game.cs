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
    TowerSpace[] towerSpaces;

    [SerializeField]
    PlaySound playSound;



    List<WayPointWalker> walkers = new List<WayPointWalker>();

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
        #region Walkers
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
        #endregion

        #region Sound when its individual (commented)
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    towerSpaces[0].TowerSpaceFires();
        //}
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    towerSpaces[1].TowerSpaceFires();
        //}
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    towerSpaces[2].TowerSpaceFires();
        //}
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    towerSpaces[3].TowerSpaceFires();
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    towerSpaces[4].TowerSpaceFires();
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    towerSpaces[5].TowerSpaceFires();
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    towerSpaces[6].TowerSpaceFires();
        //}
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    towerSpaces[7].TowerSpaceFires();
        //}
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    towerSpaces[8].TowerSpaceFires();
        //}
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    towerSpaces[9].TowerSpaceFires();
        //}
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    towerSpaces[10].TowerSpaceFires();
        //}
        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    towerSpaces[11].TowerSpaceFires();
        //}
        #endregion

        #region singular sound control
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playSound.StartBeep();
        }
        #endregion



    }

}
