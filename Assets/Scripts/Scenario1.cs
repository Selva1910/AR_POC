using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Scenario1 : MonoBehaviour
{
    [SerializeField] private Button nextButton;
    [SerializeField] private VideoPlayer videoPlayer;
    void Start()
    {
        nextButton.gameObject.SetActive(false);
        nextButton.onClick.AddListener(MoveNextScene);
        videoPlayer.loopPointReached += ShowStart;
    }

    private void ShowStart(VideoPlayer source)
    {
        source.Pause();
        nextButton.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (videoPlayer == null)
            return;
    }

    private void MoveNextScene()
    {
        SceneManager.LoadScene("AR_Viewer");
    }

}
