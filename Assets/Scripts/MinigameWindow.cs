using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameWindow : MonoBehaviour
{
    public string MinigameName = "Unnamed";
    bool Dragging = false;

    void Start()
    {
        
    }

    public void Rotate() {
        Debug.Log("Rotating MinigameWindow " + MinigameName + " 90 Degrees.");
        transform.Rotate(new Vector3(0f, 0f, 90f));
    }

    public void Quit()
    {
        Debug.Log("Closing MinigameWindow " + MinigameName + ".");
        Destroy(gameObject);
    }

    public void BeginDrag() {
        Debug.Log("Begin Dragging MinigameWindow " + MinigameName + ".");
        Dragging = true;
    }

    public void EndDrag() {
        Debug.Log("End Dragging MinigameWindow " + MinigameName + ".");
        Dragging = false;
    }

    void Update()
    {
        
    }
}
