using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class PlaySound : MonoBehaviour
{
    public ProceduralAudio pAudio;
    public AudioSource audioSource;
    public float time;
    // Start is called before the first frame update
    public void Start()
    {
        pAudio = gameObject.GetComponent<ProceduralAudio>();
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource.enabled)
        {
            audioSource.enabled = false;
            Debug.Log("turned sound off initially");
        }
        if (pAudio.enabled)
        {
            pAudio.enabled = false;
            Debug.Log("turned sound off initially");
        }

    }

    // Update is called once per frame
    public void StartBeep()
    {
        Debug.Log("start beep");
        StartCoroutine("Beep");
    }

    public IEnumerator Beep()
    {
        Debug.Log("in the coroutine");
        if (audioSource.enabled == false)
        {
            audioSource.enabled = true;

        }
        if (pAudio.enabled == false)
        {
            pAudio.enabled = true;

        }
        yield return new WaitForSeconds(time);
        audioSource.enabled = false;
        pAudio.enabled = false;

    }
}
