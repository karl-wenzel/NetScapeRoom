using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameWindow : MonoBehaviour
{
    public string MinigameName = "Unnamed";
    [Tooltip("Set to true, if you want the Minigame to be automatically parented to the canvas and be spawned at UI position")]
    public bool InstantiateInUISpace = false;
    bool Dragging = false;
    Vector3 StartMousePosition;
    Vector3 StartWindowPosition;

    [Space]
    [Header("↓ reference, dont change ↓")]
    public Animui.PlopUpGraphical SpritePlopUpAnimator;
    public MinigameController minigameController;
    public Animui.RotateAnimation rotater;
    public RectTransform CollideWithScreenBoundariesShape;
    Canvas myCanvas;

    int RotationCount = 0;

    [Header("Audio")]
    private AudioSource audioSource;
    public AudioClip PopUp;
    public AudioClip Close;

    public void Rotate()
    {
        RotationCount++;
        Debug.Log("Rotating MinigameWindow " + MinigameName + " 90 Degrees.");
        rotater.TransitionToRotation(0, new Vector3(0f, 0f, (RotationCount % 4) * 90f));
        //if (InstantiateInUISpace) CorrectPosition();
    }

    public void Quit()
    {
        Debug.Log("Closing MinigameWindow " + MinigameName + ".");
        SpritePlopUpAnimator.PlayAnimation(1);
        if (Close != null) audioSource.PlayOneShot(Close);
        Destroy(gameObject, 0.2f);
    }

    public void BeginDrag()
    {
        Debug.Log("Begin Dragging MinigameWindow " + MinigameName + ".");
        Dragging = true;
        SpritePlopUpAnimator.PlayAnimation(2);
        StartMousePosition = InstantiateInUISpace ? Input.mousePosition : Camera.main.ScreenToWorldPoint(Input.mousePosition);
        StartWindowPosition = transform.position;
    }

    public void EndDrag()
    {
        Debug.Log("End Dragging MinigameWindow " + MinigameName + ".");
        Dragging = false;
    }

    /*
    public bool CorrectPosition()
    {
        return false;
        print(myCanvas);
        float width = myCanvas.pixelRect.width;
        float height = myCanvas.pixelRect.height;
        bool CorrectedSomething = false;
        if (transform.position.x + CollideWithScreenBoundariesShape.sizeDelta.x / 2f > width/2f)
        {
            CorrectedSomething = true;
            transform.position = new Vector3(width/2f - CollideWithScreenBoundariesShape.sizeDelta.x / 2f, transform.position.y, transform.position.z);
        }
        if (transform.position.x - CollideWithScreenBoundariesShape.sizeDelta.x / 2f < -width/2f)
        {
            CorrectedSomething = true;
            transform.position = new Vector3(-width / 2f + CollideWithScreenBoundariesShape.sizeDelta.x / 2f, transform.position.y, transform.position.z);
        }
        if (transform.position.y + CollideWithScreenBoundariesShape.sizeDelta.y / 2f > height/2f)
        {
            CorrectedSomething = true;
            transform.position = new Vector3(transform.position.x, height/2f - CollideWithScreenBoundariesShape.sizeDelta.y / 2f, transform.position.z);
        }
        if (transform.position.y - CollideWithScreenBoundariesShape.sizeDelta.y / 2f < -height/2f)
        {
            CorrectedSomething = true;
            transform.position = new Vector3(transform.position.x, -height / 2f + CollideWithScreenBoundariesShape.sizeDelta.y / 2f, transform.position.z);
        }
        return CorrectedSomething;
    }
    */

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if(PopUp != null) audioSource.PlayOneShot(PopUp);
    }

    void Update()
    {
        if (Dragging)
        {
            transform.position = StartWindowPosition + ((InstantiateInUISpace ? Input.mousePosition : Camera.main.ScreenToWorldPoint(Input.mousePosition)) - StartMousePosition);
            //if (InstantiateInUISpace && CorrectPosition()) EndDrag();
        }
    }
}
