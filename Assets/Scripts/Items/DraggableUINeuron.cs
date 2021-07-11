using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableUINeuron : MonoBehaviour
{
    public float DragSpeed = 10;

    private bool IsDragging = false;

    private Vector3 TargetPosition;


    private static int ColliderVarianz = 5;

    private int Layer = 0;

    private int NeuronRow = 0;


    private static int xLayer1 = -67;
    private static int xLayer2 = 0;
    private static int xLayer3 = 0;
    private static int xLayer4 = 0;

    private static int yRow1 =11;
    private static int yRow2 = -8;
    private static int yRow3 = -27;
    private static int yRow4 = -46;



    public void Start()
    {
        TargetPosition = transform.position;
    }

    public void Update()
    {
       // Debug.Log(transform.localPosition.y);

        //Detect right Neuron Layer (Column)
        if (transform.localPosition.x < (xLayer1 + ColliderVarianz) && transform.localPosition.x > (xLayer1 - ColliderVarianz))
        {
           // Debug.Log("First Layer Radius");
        }

        //Detect right Neuron Row
        if (transform.localPosition.y < (yRow1 + ColliderVarianz) && transform.localPosition.y > (yRow1 - ColliderVarianz))
        {
           // Debug.Log("ROW1");
        }
        if (transform.localPosition.y < (yRow2 + ColliderVarianz) && transform.localPosition.y > (yRow2 - ColliderVarianz))
        {
            //Debug.Log("ROW2");
        }
        if (transform.localPosition.y < (yRow3 + ColliderVarianz) && transform.localPosition.y > (yRow3 - ColliderVarianz))
        {
           // Debug.Log("ROW3");
        }
        if (transform.localPosition.y < (yRow4 + ColliderVarianz) && transform.localPosition.y > (yRow4 - ColliderVarianz))
        {
           // Debug.Log("ROW4");
        }

        transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * DragSpeed);
    }





    public void BeginDrag()
    {
        IsDragging = true;
        TargetPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }

    public void Drag()
    {
        TargetPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }

    public void EndDrag()
    {
        IsDragging = false;
    }


}
