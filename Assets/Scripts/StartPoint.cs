using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [SerializeField]
    private EndPoint[] endPoints;

    public EndPoint GetEnd()
    {
        if(endPoints.Length > 1)
        {
            return endPoints[Random.Range(0, endPoints.Length)];
        }
        else
        {
            return endPoints[0];
        }
    }

    public void SpawnEnemy()
    {
        //todo
    }

    public static Vector2 LerpStartEnd(StartPoint s, EndPoint e, float t)
    {
        return Vector2.LerpUnclamped(s.transform.position, e.transform.position, t);
    }
}
