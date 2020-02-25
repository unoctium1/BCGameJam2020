using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftUp : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float maxHeight;

    private float initialPos;
    

    void Start()
    {
        initialPos = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.localPosition;
        pos.y += speed * Time.deltaTime;
        if(pos.y > maxHeight)
        {
            pos.y = initialPos;
        }
        transform.localPosition = pos;
    }
}
