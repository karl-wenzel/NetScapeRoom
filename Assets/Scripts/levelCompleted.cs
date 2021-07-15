using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelCompleted : MonoBehaviour
{
    public Image m_img;

    public static levelCompleted me;

    private void Start()
    {
        me = this;
    }

    public void LevelComplete() {
        m_img.enabled = true;
        StartCoroutine(Fade());
    }

    IEnumerator Fade() {
        yield return new WaitForSeconds(2f);
        m_img.CrossFadeAlpha(0f, 2f, true);
    }
}
