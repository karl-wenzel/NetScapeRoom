using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOnce : MonoBehaviour
{
    private static OpenOnce _instance;
    public static OpenOnce Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
