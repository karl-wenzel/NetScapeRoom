using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnGameStart : MonoBehaviour
{
    void Start()
    {
        foreach (Renderer r in gameObject.GetComponentsInChildren<Renderer>())
        {
            r.enabled = false;
        }
    }

}
