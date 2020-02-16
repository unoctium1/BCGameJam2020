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

[SelectionBase]
public class ButtonBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject depressed = default;
    [SerializeField]
    GameObject unpressed = default;

    [SerializeField]
    Transform towerBase = default;

    [SerializeField]
    bool isPressed;

    public TowerType towerType;
    public KeyCode towerKey;

    [SerializeField]
    public TowerBehavior tower;

    private void OnEnable()
    {
        if (isPressed)
            PressButton(false);
        else
            UnPressButton();
    }

    public TowerBehavior SpawnTower(TowerBehavior prefab)
    {
        TowerBehavior tower = Instantiate(prefab, towerBase);
        tower.transform.localPosition = Vector3.zero;
        this.tower = tower;
        return tower;
    }

    public void PressButton(bool unPressAfter)
    {
        isPressed = true;
        unpressed.gameObject.SetActive(false);
        depressed.gameObject.SetActive(true);
        if(unPressAfter)
            Invoke("UnPressButton", 1f);
    }

    public void OnMouseOver()
    {
        if(Game.instance.Phase1)
            PressButton(false);
    }

    public void OnMouseExit()
    {
        if (Game.instance.Phase1 && Game.instance.SelectedButton != this)
            UnPressButton();
    }

    public void OnMouseDown()
    {
        if (Game.instance.Phase1)
            Game.instance.SelectedButton = this;
    }

    public void UnPressButton()
    {
        unpressed.gameObject.SetActive(true);
        depressed.gameObject.SetActive(false);
    }

    private void OnValidate()
    {
        unpressed.gameObject.SetActive(!isPressed);
        depressed.gameObject.SetActive(isPressed);
    }
    public void TowerSpaceFires()
    {
        if (Game.instance.Phase1)
        {
            Game.instance.SelectedButton = this;
        }
        else
        {
            #region sound part
            PressButton(true);
            if (tower != null)
            {
                tower.StartFiring();
            }
            PlaySound playSound = GetComponent<PlaySound>();
            playSound.StartBeep();
            #endregion
        }
    }


    public void BuildTowerSpace()
    {

    }

    public void UpgradeTowerSpace()
    {

    }
}
