using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public ProceduralAudio pAudio;
    // Start is called before the first frame update
    public void Start()
    {
        pAudio = gameObject.GetComponent<ProceduralAudio>();
        if (pAudio)
            pAudio.enabled = false;
    }

    // Update is called once per frame
    public void StartBeep()
    {
        Debug.Log("start beep");
        if (pAudio.enabled == false)
            StartCoroutine("Beep");
    }

    public IEnumerable Beep()
    {
        Debug.Log("in the coroutine");
        if (pAudio.enabled == false)
            pAudio.enabled = true;
        yield return new WaitForSeconds(1);
        pAudio.enabled = false;
        yield return null;

    }
}
