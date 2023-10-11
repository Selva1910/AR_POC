using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrinalTracked : ARObjectTracked
{
    public override string objectName => "Cube";


    private string desc = "Follow the steps to clean the urinal \n\nStep 1. Flush the urinal\n\nStep 2. Remove the mat\n\nStep 3. Apply the toilet cleaner inside area of the urinal\n\nStep 4. Spray disinfectant around the urinal\n\nStep 5. Clean with a microfiber cloth\n\nStep 6. Clean the inside area of urinal with a cleaning brush\n\nStep 7. Flush the urinal\n\nStep 8. Put back a clean mat\n\nTo watch the video, press the play icon.";

    public AudioClip clip;

    public override IARObjectOptions[] options => new IARObjectOptions[]
    {
        new ARObjectOptions("Instructions",
            "infoIcon",
            ShowInstructions),
        new ARObjectOptions("Watch Video",
            "playIcon",
            ShowCleaning),
    };

    private void ShowInstructions()
    {
        Debug.Log("Cleaning Instructions!");
        FindAnyObjectByType<OptionBoard>().ShowInstructions(desc, "Follow");
    }

    private void ShowCleaning()
    {
        Debug.Log("Cleaning Demo Video!");
        FindAnyObjectByType<OptionBoard>().PlayVideo("Urinal Cleaning video");
    }

}