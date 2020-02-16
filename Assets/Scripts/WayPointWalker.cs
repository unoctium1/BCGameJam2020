﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointWalker : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private StartPoint currStart;
    private EndPoint currentEnd;

    private float progress;

    public Direction walkerDir;
    [SerializeField]
    private Animator anim;
    private EnemyFactory originFactory;
    private int id = int.MinValue;

    public EnemyFactory OriginFactory
    {
        get => originFactory;
        set
        {
            Debug.Assert(originFactory == null, "Redefined origin factory!");
            originFactory = value;
        }
    }

    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            if (id == int.MinValue && value != int.MinValue)
            {
                id = value;
            }
            else
            {
                Debug.LogError("Not allowed to change d.");
            }
        }
    }


    public void Initialize(StartPoint start)
    {
        progress = 0.00f;
        currStart = start;
        currentEnd = currStart.GetEnd();
        RotateWalker();
        transform.position = currStart.transform.position;
        gameObject.SetActive(true);
    }

    public bool UpdateWalker()
    {
        progress += Time.deltaTime * speed;
        while (progress >= 1f)
        {
            progress = (progress - 1f) / speed;
            transform.position = currentEnd.transform.position;
            if (currentEnd.CorrespondingStartPoint != null)
            {
                currStart = currentEnd.CorrespondingStartPoint;
                currentEnd = currStart.GetEnd();
                RotateWalker();
                progress *= speed;
            }
            else
            {
                return false;
            }
        }
        Vector2 pos = StartPoint.LerpStartEnd(currStart, currentEnd, progress);
        transform.position = pos;
        return true;
    }

    public void EndBehavior()
    {
        StartCoroutine(DestroyWalker());
    }

    private IEnumerator DestroyWalker()
    {
        transform.position = currentEnd.transform.position;
        anim.SetTrigger("setIdle");
        yield return new WaitForSeconds(3f);
        anim.StopPlayback();
        OriginFactory.Reclaim(this);
    }

    private void RotateWalker()
    {
        float startX = currStart.transform.position.x;
        float endX = currentEnd.transform.position.x;
        if (startX == endX)
        {
            anim.SetTrigger("setBack");
            walkerDir = Direction.down;

        }
        else if(startX > endX) {
            anim.SetTrigger("setLeft");
            Vector3 scale = transform.localScale;
            scale.x = scale.x < 0 ? scale.x * -1 : scale.x;
            transform.localScale = scale;
            walkerDir = Direction.left;
        }else{
            anim.SetTrigger("setLeft");
            Vector3 scale = transform.localScale;
            scale.x = scale.x > 0 ? scale.x * -1 : scale.x;
            transform.localScale = scale;
            walkerDir = Direction.right;
        }
    }
}