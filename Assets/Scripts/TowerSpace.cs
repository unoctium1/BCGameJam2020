using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType
{
    DamageSingular = 0,
    DamageChain = 1,
    DamagePenetration = 2,
    Slowness = 4,
    Effects = 5,
    Paralysis = 6,
    Poison = 7,
    Powerup = 8
}





public class TowerSpace:MonoBehaviour
{
    public TowerType towerType;
    public KeyCode towerKey;


    public void TowerSpaceFires()
    {
        #region sound part

        #endregion

    }


    public void BuildTowerSpace()
    {

    }

    public void UpgradeTowerSpace()
    {

    }



    
}
