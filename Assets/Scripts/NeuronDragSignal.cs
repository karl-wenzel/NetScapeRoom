using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NeuronDragSignal : MonoBehaviour
{
    //true if the signal has pass the layer on the right neuron, otherwise false
    private bool layer1 = false;
    private bool layer2 = false;
    private bool layer3 = false;
    private bool layer4 = false;

    public float Speed = 1;

    public MinigameController controller;

    public TextMeshProUGUI output;

    private int currentLayer = 0;
    private int currentNode = 0;

    public Vector3 TargetPosition;

    // Start is called before the first frame update
    void Start()
    {
        output.text = "NeuronDrag Minispiel";
        TargetPosition = transform.localPosition;
    }

    // Update is called once per frame

    float StartTime = 0f;
    float LerpTimeTotal = 0.5f;

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, TargetPosition, (Time.time - StartTime)/LerpTimeTotal);
    }

    public float getSpeed()
    {
        return Speed;
    }
    public int getCurrentLayer()
    {
        return currentLayer;
    }
    public void setCurrentLayer(int layer)
    {
        currentLayer = layer; ;
    }
    public int getCurrentNode()
    {
        return currentNode;
    }
    public void setCurrentNode(int node)
    {
        currentNode = node; 
    }

    public void setTargetPosition(Vector3 target)
    {
        StartTime = Time.time;
        TargetPosition = target;
    }


    public void setLayer(int layer, bool value)
    {
        switch (layer)
        {
            case 1:
                layer1 = value;
                break;
            case 2:
                layer2 = value;
                break;
            case 3:
                layer3 = value;
                break;
            case 4:
                layer4 = value;
                break;
        }
        Debug.Log("Layer "+ layer +" gesetzt: " + value);


        if (layer1 && layer2 && layer3 && layer4)
        {
          // Debug.Log("RICHTIGEN PFAD GENOMMEN");
            controller.SuccessfulMinigame();
        }
    }
}
