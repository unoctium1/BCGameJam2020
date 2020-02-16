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

    private void OnEnable()
    {
        if (isPressed)
            PressButton();
        else
            UnPressButton();
    }

    private void OnMouseDown()
    {
        PressButton();
    }

    void PressButton()
    {
        isPressed = true;
        unpressed.gameObject.SetActive(false);
        depressed.gameObject.SetActive(true);
        Invoke("UnPressButton", 1f);
    }

    void UnPressButton()
    {
        isPressed = false;
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
        #region sound part
        PressButton();
        PlaySound playSound = GetComponent<PlaySound>();
        playSound.StartBeep();
        #endregion

    }


    public void BuildTowerSpace()
    {

    }

    public void UpgradeTowerSpace()
    {

    }
}
