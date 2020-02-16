using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnChannel : MonoBehaviour
{
    [SerializeField]
    AudioSpectrum spect;

    [SerializeField]
    int band;

    [SerializeField]
    float maxHeight;

    Vector2 dimensions;

    void Start()
    {
        dimensions = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        dimensions.y = spect.PeakLevels[band] * maxHeight;
        transform.localScale = dimensions;
    }
}
