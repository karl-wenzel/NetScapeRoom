using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoxBehavior : MonoBehaviour
{
    public ItemSlotManager[] Itemslots;
    public Lever Lever;
    public IndicatorLight light;

    private bool IsOn = false;



    public void Update()
    {


        if (Lever.Check() && CheckFuses())
        {
            light.TurnOn();
            IsOn = true;
        }
        else
        {
            IsOn = false;
            Lever.TurnOff();
            light.TurnOff();
        }

    }

    public bool HasPower()
    {
        return IsOn;
    }


    bool CheckFuses()
    {
        bool valid = true;

        for(int i=0; i<Itemslots.Length; i++)
        {
            if (Itemslots[i].CheckIfEmpty()) return false;
        }

        return valid;
    }
}
