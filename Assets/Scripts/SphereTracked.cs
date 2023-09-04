using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTracked : ARObjectTracked
{
    public override string objectName => "Sphere";

    public override IARObjectOptions[] options => new IARObjectOptions[]
    {
    };

    private void ShowCleaning()
    {
        Debug.Log("Sphere Cleaning");
    }

    private void ShowUsage()
    {
        Debug.Log("Using");
    }

}
