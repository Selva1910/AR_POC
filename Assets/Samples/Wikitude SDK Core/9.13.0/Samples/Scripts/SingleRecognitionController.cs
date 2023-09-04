/******************************************************************************
 * File: SingleRecognitionController.cs
 * Copyright (c) 2021 Qualcomm Technologies, Inc. and/or its subsidiaries. All rights reserved.
 *  2021 Wikitude GmbH.
 * 
 * Confidential and Proprietary - Qualcomm Technologies, Inc.
 *
 ******************************************************************************/

﻿using UnityEngine.UI;
using Wikitude;

public class SingleRecognitionController : SampleController
{
    public ImageTracker Tracker;
    public Text InfoText;
    public Button RecognizeButton;
    public Text ButtonText;

    public void OnRecognizeClicked() {
        RecognizeButton.enabled = false;
        ButtonText.text = "Recognizing...";

        Tracker.CloudRecognitionService.Recognize();
    }

    /* Called when the tracker finished initializing and is ready to receive recognition requests. */
    public void OnConnectionInitialized() {
        RecognizeButton.enabled = true;
        ButtonText.text = "Recognize";
    }

    public void OnConnectionInitializationError(Error error) {
        InfoText.text = "Error initializing cloud connection!\n" + error.Message;
        PrintError("Error initializing cloud connection!", error, true);
    }

    public void OnRecognitionResponse(CloudRecognitionServiceResponse response) {
        RecognizeButton.enabled = true;
        ButtonText.text = "Recognize";
        if (response.Recognized) {
            InfoText.text = "Target collection for <b>" + response.Info["name"] + "</b> loaded";
        } else {
            InfoText.text = "No target recognized";
        }
    }

    public void OnRecognitionError(Error error) {
        RecognizeButton.enabled = false;
        ButtonText.text = "Recognize";
        InfoText.text = "Recognition failed!";

        PrintError("Recognition error!", error, true);
    }
}
