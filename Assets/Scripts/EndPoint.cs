using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField]
    private bool isDestination;

    public Dial end = default(Dial);

    public StartPoint CorrespondingStartPoint { get; private set; }

    private void Start()
    {
        if (!isDestination)
        {
            CorrespondingStartPoint = GetComponent<StartPoint>();
        }
        else
        {
            CorrespondingStartPoint = null;
        }
    }
}
