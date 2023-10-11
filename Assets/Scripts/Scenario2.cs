using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Scenario2 : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private VideoPlayer videoPlayer;
    void Start()
    {
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        startButton.onClick.AddListener(MoveNextScene);
        exitButton.onClick.AddListener(() => Application.Quit());
        videoPlayer.loopPointReached += ShowStart;
    }

    private void ShowStart(VideoPlayer source)
    {
        source.Pause();
        startButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (videoPlayer == null)
            return;
    }

    private void MoveNextScene()
    {
        SceneManager.LoadScene("AR_Viewer_Wiki");
        //SceneManager.LoadScene("AR_Viewer");
    }

}
