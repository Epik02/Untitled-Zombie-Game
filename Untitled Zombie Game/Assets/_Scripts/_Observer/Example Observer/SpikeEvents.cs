using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Events
public abstract class SpikeEvents
{
    public abstract Color SpikeEditorColor();
}


public class YellowMat : SpikeEvents
{
    public override Color SpikeEditorColor()
    {
        return Color.yellow;
    }
}


public class GreenMat : SpikeEvents
{
    public override Color SpikeEditorColor()
    {
        return Color.green;
    }
}
