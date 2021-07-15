using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NeuronDragSignal : MonoBehaviour
{
    //true if the signal has pass the layer ON THE RIGHT NEURON, otherwise false
    private bool layer1;
    private bool layer2;
    private bool layer3;
    private bool layer4;

    //true if the signal has pass the layer
    private bool isSetLayer1;
    private bool isSetLayer2;
    private bool isSetLayer3;
    private bool isSetLayer4;

    public float Speed = 1;

    public MinigameController controller;

    public TextMeshProUGUI output;

    private int currentLayer;
    private int currentNode;

    private Vector3 TargetPosition;

    private GameObject signalStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        signalStartPosition = GameObject.Find("SignalStartPosition");
        // output.text = "NeuronDrag Minispiel";
        TargetPosition = signalStartPosition.transform.localPosition;

        layer1 = false;
        layer2 = false;
        layer3 = false;
        layer4 = false;

        isSetLayer1 = false;
        isSetLayer2 = false;
        isSetLayer3 = false;
        isSetLayer4 = false;

        currentLayer = 0;
        currentNode = 0;

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
        currentLayer = layer; 
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


    public bool setLayer(int layer, bool value)
    {
        bool moveSignal = false;
        output.text = "";

        switch (layer)
        {
            case 1:
                if (currentLayer == 0 || currentLayer == 2)
                {
                    layer1 = value;
                    isSetLayer1 = true;
                    setCurrentLayer(1);
                    Debug.Log("Layer " + layer + " gesetzt: " + value);
                    moveSignal = true;
                }
                else
                {
                    output.text = "Ebenen können nicht übersprungen werden";
                }
                break;
            case 2:
                if (currentLayer == 1 || currentLayer == 3)
                {
                    layer2 = value;
                    isSetLayer2 = true;
                    setCurrentLayer(2);
                    Debug.Log("Layer " + layer + " gesetzt: " + value);
                    moveSignal = true;
                }
                else
                {
                    output.text = "Ebenen können nicht übersprungen werden";
                }
                break;
            case 3:
                if (currentLayer == 2 || currentLayer == 4)
                {
                    layer3 = value;
                    isSetLayer3 = true;
                    setCurrentLayer(3);
                    Debug.Log("Layer " + layer + " gesetzt: " + value);
                    moveSignal = true;
                }
                else
                {
                    output.text = "Ebenen können nicht übersprungen werden";
                }
                break;
            case 4:
                if (currentLayer == 3)
                {
                    layer4 = value;
                    isSetLayer4 = true;
                    setCurrentLayer(4);
                    Debug.Log("Layer " + layer + " gesetzt: " + value);
                    moveSignal = true;
                }
                else
                {
                    output.text = "Ebenen können nicht übersprungen werden";
                }
                break;
        }
        
        return moveSignal;
    }

    public void checkRightPath()
    {
        if (isSetLayer1 && isSetLayer2 && isSetLayer3 && isSetLayer4)
        {
            if (layer1 && layer2 && layer3 && layer4)
            {
                // Richtiger Pfad wurde genommen
                output.text = "Super! Ihr habt den richtigen Pfad gefunden.";
                
                controller.SuccessfulMinigame();
            }
            else
            {
                output.text = "Falscher Pfad, bitte erneut versuchen!";
                Start();
            }
        }
       
    }



}
