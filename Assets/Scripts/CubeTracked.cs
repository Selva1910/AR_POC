using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTracked : ARObjectTracked
{
    public override string objectName => "Cube";

    public override IARObjectOptions[] options => new IARObjectOptions[]
    {
        new ARObjectOptions("Cleaning",
            "How to Clean the Urinal",
            "infoIcon",
            ShowCleaning),
    };

    private void ShowCleaning()
    {
        Debug.Log("Cleaning Demo");
        FindAnyObjectByType<OptionBoard>().PlayVideo("Urnal Cleaning Explaining Video-02");
    }

}