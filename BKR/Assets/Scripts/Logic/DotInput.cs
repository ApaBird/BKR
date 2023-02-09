using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotInput : IClickComponent
{
    private DotOutput dotOutput = null;

    public override GameObject Select(Camera cam)
    {

        if (dotOutput != null)
        {
            dotOutput.SetDotInput(null);
            dotOutput = null;
        }
        return null;
    }

    public void SetDotOutput(DotOutput dot)
    {
        if (dotOutput == null)
            dotOutput = dot;
    }

    public override void Unselect()
    {
        dotOutput = null;
    }
}
