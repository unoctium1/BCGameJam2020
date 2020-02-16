using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
