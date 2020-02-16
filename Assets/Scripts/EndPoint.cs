using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField]
    private bool isDestination;

    public StartPoint CorrespondingStartPoint { get; private set; } = null;

    private void Start()
    {
        if (!isDestination)
        {
            CorrespondingStartPoint = GetComponent<StartPoint>();
        }
    }
}
