using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameWindow : MonoBehaviour
{
    public string MinigameName = "Unnamed";
    bool Dragging = false;
    Vector3 StartMousePosition;
    Vector3 StartWindowPosition;

    int RotationCount = 0;
    public void Rotate() {
        RotationCount++;
        Debug.Log("Rotating MinigameWindow " + MinigameName + " 90 Degrees.");
        transform.eulerAngles = new Vector3(0f, 0f, (RotationCount % 4) * 90f);
    }

    public void Quit()
    {
        Debug.Log("Closing MinigameWindow " + MinigameName + ".");
        Destroy(gameObject);
    }

    public void BeginDrag() {
        Debug.Log("Begin Dragging MinigameWindow " + MinigameName + ".");
        Dragging = true;
        StartMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        StartWindowPosition = transform.position;
    }

    public void EndDrag() {
        Debug.Log("End Dragging MinigameWindow " + MinigameName + ".");
        Dragging = false;
    }

    void Update()
    {
        if (Dragging) {
            print(StartWindowPosition);
            print(Camera.main);
            transform.position = StartWindowPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - StartMousePosition);
        }
    }
}
