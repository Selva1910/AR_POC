using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Scene1 : MonoBehaviour
{
    public GameObject player;
    public Button startBtn;
    public Image ima;
    public GameObject audio2;

    void Start()
    {
        startBtn.onClick.AddListener(LoadAR);
        PlayVideo();
    }

    private void LoadAR()
    {
        SceneManager.LoadScene(1);
    }

    private void PlayVideo()
    {
        player.SetActive(true);
        var viplayer = player.GetComponent<VideoPlayer>();
        StartCoroutine(WaitTillSeconds(8, () =>
        {
            startBtn.gameObject.SetActive(true);
            PlayAudio2();
        }));
    }
    private void PlayAudio2()
    {
        audio2.SetActive(true);
    }

    private IEnumerator WaitTillSeconds(float time, Action action)
    {
        yield return new WaitForSecondsRealtime(time);
        action();
    }
}
