using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Wants to know when another object does something interesting 
public abstract class Observer 
{
    public abstract void OnNotify();
}

public class SpikeBall : Observer
{
    //The box gameobject which will do something
    GameObject spikeObj;
    //What will happen when this box gets an event
    SpikeEvents spikeEvent;

    public SpikeBall(GameObject spikeObj, SpikeEvents spikeEvent)
    {
        this.spikeObj = spikeObj;
        this.spikeEvent = spikeEvent;
    }

    //What the box will do if the event fits it (will always fit but you will probably change that on your own)
    public override void OnNotify()
    {
        SpikeColor(spikeEvent.SpikeEditorColor());
    }

    //The box will always jump in this case
    void SpikeColor(Color mat)
    {
        //If the box is close to the ground
        spikeObj.GetComponent<Renderer>().materials[0].color = mat;
    }
}
