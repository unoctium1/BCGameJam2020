using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dial : MonoBehaviour
{
    [SerializeField]
    GameObject fullSprite;
    [SerializeField]
    GameObject twoSprite;
    [SerializeField]
    GameObject oneSprite;
    [SerializeField]
    GameObject brokenSprite;
    [SerializeField]
    EndPoint destination;
    [SerializeField]
    GameObject startPoint;

    private GameObject[] arr = new GameObject[4];

    private int damage;

    public bool IsBroken {
        get { return damage >= 3; }
    }

    public void Start()
    {
        damage = 0;
        arr[0] = fullSprite;
        arr[1] = twoSprite;
        arr[2] = oneSprite;
        arr[3] = brokenSprite;

        arr[damage].SetActive(true);
        for(int i = 1; i < 4; i++)
        {
            arr[i].SetActive(false);
        }
    }

    public void DealDamage()
    {
        if(damage < 3)
        {
            arr[damage].SetActive(false);
            damage++;
            arr[damage].SetActive(true);
            if (damage == 3)
            {
                BreakDial();
            }
        }
        
    }

    private void BreakDial()
    {
        startPoint.SetActive(false);
        destination.enabled = false;
    }
}
