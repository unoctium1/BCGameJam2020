using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [SerializeField]
    private EndPoint[] endPoints;

    [SerializeField]
    private List<EndPoint> ends = new List<EndPoint>();

    [SerializeField]
    bool useList;

    public EndPoint GetEnd()
    {
        if (useList)
        {
            int index = Random.Range(0, ends.Count);
            if(!ends[index].gameObject.activeSelf)
            {
                ends.RemoveAt(index);
                return GetEnd();
            }
            return ends[index];

        }
        if(endPoints.Length > 1)
        {
            return endPoints[Random.Range(0, endPoints.Length)];
        }
        else
        {
            return endPoints[0];
        }
    }

    public static Vector2 LerpStartEnd(StartPoint s, EndPoint e, float t)
    {
        return Vector2.LerpUnclamped(s.transform.position, e.transform.position, t);
    }
}
