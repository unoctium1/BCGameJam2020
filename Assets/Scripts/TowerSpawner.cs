using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{

    public static TowerSpawner instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    [SerializeField]
    private TowerBehavior[] towerPrefabs;

    public bool TrySpawn(int index)
    {
        TowerBehavior tower = instance.towerPrefabs[index];

        //test if can afford here
        Debug.Log("Here");
        if(Game.instance.SelectedButton != null)
        {
            // A button is already selected ,spawn on the button
            Debug.Log("button selected");
            Game.instance.SpawnTowerOnButton(tower);
        }
        else
        {
            Debug.Log("mouse spawn");
            TowerBehavior go = Instantiate(tower);
            Game.instance.ActiveTowerToSpawn = go;
        }

        return true;

    }

    public void SpawnSimple() => TrySpawn(0);
    public void SpawnChain() => TrySpawn(1);
    public void SpawnRange() => TrySpawn(2);

    public void SpawnCluster() => TrySpawn(3);

    /*private void Update()
    {
        if(Game.instance.ActiveTowerToSpawn != null)
        {
            Game.instance.ActiveTowerToSpawn.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }*/


}
