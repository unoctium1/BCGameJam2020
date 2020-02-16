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

    [SerializeField]
    GameObject AudioListener;

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


    //void Update()
    //{
    //    //#region firing actions switch key
        

    //}

}
