using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftUp : MonoBehaviour
{
    [SerializeField]
    float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.localPosition;
        pos.y += speed * Time.deltaTime;
        if(pos.y > 1.5)
        {
            pos.y = -1;
        }
        transform.localPosition = pos;
    }
}
