using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuronDragNodes : MonoBehaviour
{
    private GameObject signal;

    private NeuronDragSignal nds; 

    //Defines the node
    public bool rightPathNode;
    public int Layer;
    public int NodeNr;

    public void Start()
    {
        signal = GameObject.Find("Signal");
        nds = signal.GetComponent<NeuronDragSignal>();
    }

    public void onClickDo()
    {

        if(nds.setLayer(Layer, rightPathNode))
        {
            nds.setTargetPosition(transform.localPosition);
        }

        nds.checkRightPath();


    }
    
}
