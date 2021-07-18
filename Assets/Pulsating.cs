using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsating : MonoBehaviour
{
    public Vector3 OriginalScale;

    public float Scale = 1.2f;
    public float Frequency = 1;

    private void Start()
    {
        OriginalScale = transform.localScale;
    }

    void Update()
    {
        Vector3 currentScale = (Mathf.Sin(Time.time * Frequency * Mathf.PI * 2) + 1) / 2 * Scale * new Vector3(1, 1, 1);
        transform.localScale = OriginalScale + currentScale;
    }
}
