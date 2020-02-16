using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameBoard : MonoBehaviour {

	[SerializeField]
	Transform ground = default;

    private int[] values;
    private bool[] keys;
    private KeyCode[] mykeys;

    const int size = 12;

    [SerializeField]
    TowerSpace[] towerSpaces;

	public void Initialize()
	{
        //Build Tower spaces
        for (int i = 0; i < 12; i++)
        {
            towerSpaces[i].BuildTowerSpace();
        }

	}

    void Awake()
    {
        values = (int[])System.Enum.GetValues(typeof(KeyCode));
        keys = new bool[values.Length];
    }


    void Update()
    {
        #region firing actions switch key
        if (Input.anyKey)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                towerSpaces[0].TowerSpaceFires();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                towerSpaces[1].TowerSpaceFires();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                towerSpaces[2].TowerSpaceFires();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                towerSpaces[3].TowerSpaceFires();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                towerSpaces[4].TowerSpaceFires();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                towerSpaces[5].TowerSpaceFires();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                towerSpaces[6].TowerSpaceFires();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                towerSpaces[7].TowerSpaceFires();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                towerSpaces[8].TowerSpaceFires();
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                towerSpaces[9].TowerSpaceFires();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                towerSpaces[10].TowerSpaceFires();
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                towerSpaces[11].TowerSpaceFires();
            }

        }
        #endregion


    }

}
