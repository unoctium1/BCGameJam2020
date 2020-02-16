using UnityEngine;
using System.Collections.Generic;

public class Game : MonoBehaviour
{

    public static Game instance;

    [SerializeField]
    private int lifes = 3;
    public int Lives { get; set; }
    public float Score { get; set; }

    public int NextWaveEnemies { get; set; }

    private int wave = 0;

    [SerializeField]
    private int initialEnemies;

    [SerializeField]
    private int enemyIncreasePerWave;

	[SerializeField]
	StartPoint[] startPoints;
	[SerializeField]
	EndPoint[] endPoints;

	[SerializeField]
	EnemyFactory enemyFactory;

    [SerializeField]
    ButtonBehavior[] buttonBehaviors;




    List<WayPointWalker> walkers = new List<WayPointWalker>();
    [SerializeField]
	List<TowerBehavior> towers = new List<TowerBehavior>();

	[SerializeField]
	float spawnSpeed = 3f;

	float spawnProgress = 0.0f;

    [SerializeField]
	bool isEnemyWavePhase = false;

    private ButtonBehavior selected;

    [SerializeField]
    public AudioSpectrum spect;

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
            selected.PressButton(false);
        }
    }

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
        Lives = lifes;
        NextWaveEnemies = initialEnemies;
    }

    public void SetPhase2()
    {

    }

    public void SetPhase1()
    {

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
			}
		}
        Physics2D.SyncTransforms();

        for (int i = 0; i < towers.Count; i++)
        {
            towers[i].TowerUpdate();
        }


    }

		
}
