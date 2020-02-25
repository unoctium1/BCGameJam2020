using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnBeat : MonoBehaviour
{
    [SerializeField]
    private AudioSpectrum spectrum;

    Vector3 startScale;
    Vector3 maxScale;
    Vector3 minScale;

    private void Start()
    {
        spectrum = Game.instance.spect;
        startScale = transform.localScale;
        maxScale = startScale * 1.5f;
        minScale = startScale * .75f;
    }

    private void Update()
    {
        this.transform.localScale = Vector3.Lerp(minScale, maxScale, spectrum.AmplitudeBuffer);
    }

}
