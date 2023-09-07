using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{

    private VideoPlayer player;
    [SerializeField] private Sprite play;
    [SerializeField] private Sprite pause;
    [SerializeField] private Image playBtn;
    private void Start()
    {
        player = GetComponent<VideoPlayer>();
    }
    public void TogglePlay()
    {
        if (player.isPlaying)
        {
            player.Pause();
            playBtn.sprite = play;
        }
        else
        {
            player.Play();
            playBtn.sprite = pause;
        }
    }
}
