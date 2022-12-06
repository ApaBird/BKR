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
            GameObject answer = dotOutput.gameObject;
            dotOutput.GetComponent<DotOutput>().Select(cam);
            dotOutput = null;
            return answer;
        }
        else 
            return null;
    }

    public void SetDotOutput(DotOutput dot)
    {
        dotOutput = dot;
    }

    public override void Unselect()
    {
        dotOutput = null;
    }
}
