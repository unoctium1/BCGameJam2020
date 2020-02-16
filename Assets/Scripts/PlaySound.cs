using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (ProceduralAudio))]
public class PlaySound : MonoBehaviour
{
    public ProceduralAudio pAudio;
    // Start is called before the first frame update
    public void Start()
    {
        pAudio = gameObject.GetComponent<ProceduralAudio>();
        if (pAudio)
        {
            pAudio.enabled = false;
            //Debug.Log("turned sound off initially");
        }
            
    }

    // Update is called once per frame
    public void StartBeep()
    {
        //Debug.Log("start beep");
        StartCoroutine("Beep");
    }

    public IEnumerator Beep()
    {
        //Debug.Log("in the coroutine");
        if (pAudio.enabled == false)
            pAudio.enabled = true;
        yield return new WaitForSeconds(1);
        pAudio.enabled = false;

    }
}
