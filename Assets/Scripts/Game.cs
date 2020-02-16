using UnityEngine;
using System.Collections.Generic;

public class Game : MonoBehaviour
{

    public static Game instance;

    public float Score { get; set; }

    public int NextWaveEnemies { get; set; }

    [SerializeField]
    private GameObject phase1Canvas = default;

    private int wave = 0;

    [SerializeField]
    private int initialEnemies;

    [SerializeField]
    private int enemyIncreasePerWave;

	[SerializeField]
	StartPoint[] startPoints;
	[SerializeField]
	Dial[] endPoints;

	[SerializeField]
	EnemyFactory enemyFactory;

    [SerializeField]
    ButtonBehavior[] buttonBehaviors;

    private int enemiesSpawned = 0;


    List<WayPointWalker> walkers = new List<WayPointWalker>();
    [SerializeField]
	List<TowerBehavior> towers = new List<TowerBehavior>();

	[SerializeField]
	float spawnSpeed = 3f;

	float spawnProgress = 0.0f;

    [SerializeField]
	bool isEnemyWavePhase = false;

    private ButtonBehavior selected;
    public ButtonBehavior SelectedButton
    {
        get => selected;
        set
        {
            if (value != selected && selected != null)
            {
                selected.UnPressButton();
            }
            selected = value;
            if (selected != null) {
                selected.PressButton(false);
                if (ActiveTowerToSpawn != null) {
                    SpawnTowerOnButton(ActiveTowerToSpawn);
                    ActiveTowerToSpawn = null;
                    SelectedButton = null;
                }
            }
        }
    }

    public void SpawnTowerOnButton(TowerBehavior tower)
    {
        towers.Add(SelectedButton.SpawnTower(tower));
    }

    public TowerBehavior ActiveTowerToSpawn { get; set; }

    public bool Phase1 => !isEnemyWavePhase;

	private WayPointWalker GetRandomWalker()
	{
		StartPoint s = startPoints[Random.Range(0, startPoints.Length)];
		WayPointWalker w = enemyFactory.GetRandom();
		w.Initialize(s);
		return w;

	}

    private void Awake()
    {
        instance = this;
        NextWaveEnemies = initialEnemies;
    }

    public void SetPhase2()
    {
        phase1Canvas.SetActive(false);
        wave++;
        SelectedButton = null;
        enemiesSpawned = 0;
        isEnemyWavePhase = true;
        Debug.Log("Enemy wave");
    }

    public void SetPhase1()
    {
        phase1Canvas.SetActive(true);
        NextWaveEnemies += enemyIncreasePerWave;
        isEnemyWavePhase = false;
    }

    private void Update()
	{

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
        bool isGameOver = true;
        for(int i = 0; i < endPoints.Length; i++)
        {
            if (!endPoints[i].IsBroken)
            {
                isGameOver = false;
                break;
            }
        }

        if (isGameOver)
        {
            Debug.Log("Game over");
            //Do some shit
        }

		spawnProgress += spawnSpeed * Time.deltaTime;
		while (spawnProgress >= 1f && enemiesSpawned < NextWaveEnemies)
		{
			spawnProgress -= 1f;
			walkers.Add(GetRandomWalker());
            enemiesSpawned++;
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
			}
		}
        Physics2D.SyncTransforms();

        for (int i = 0; i < towers.Count; i++)
        {
            towers[i].TowerUpdate();
        }

        if(walkers.Count == 0 && enemiesSpawned >= NextWaveEnemies)
        {
            SetPhase1();
        }


    }

		
}
