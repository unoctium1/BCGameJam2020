using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private TowerBehavior[] towerPrefabs;

    public bool TrySpawn(int index)
    {
        TowerBehavior tower = towerPrefabs[index];

        //test if can afford here

        if(Game.instance.SelectedButton != null)
        {
            // A button is already selected ,spawn on the button

            Game.instance.SpawnTowerOnButton(tower);
        }
        else
        {
            TowerBehavior go = Instantiate(tower);
            Game.instance.ActiveTowerToSpawn = go;
        }

        return true;

    }

    private void Update()
    {
        if(Game.instance.ActiveTowerToSpawn != null)
        {
            Game.instance.ActiveTowerToSpawn.transform.position = Input.mousePosition;
        }
    }


}
