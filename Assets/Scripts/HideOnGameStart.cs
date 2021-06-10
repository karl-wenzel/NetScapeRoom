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
        foreach (UnityEngine.UI.Image i in gameObject.GetComponentsInChildren<UnityEngine.UI.Image>())
        {
            i.enabled = false;
        }
    }

}
