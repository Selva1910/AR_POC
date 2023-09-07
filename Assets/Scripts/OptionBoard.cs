using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class OptionBoard : MonoBehaviour
{
    private Canvas optionBoardCanvas;
    private IARObjectOptions[] options;
    [SerializeField] private VideoPlayer player;
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        optionBoardCanvas = GetComponent<Canvas>();
        optionBoardCanvas.worldCamera = Camera.main;
    }
    private void Start()
    {
        ShowOptions(GetComponentInParent<ARObjectTracked>());
        GetComponentInParent<ARObjectTracked>().OnARObjectEnable += ShowOptions;
    }
    private void ShowOptions(ARObjectTracked tracked)
    {
        Debug.Log("Getting Options");
        GetOptions(tracked);
        foreach (var o in options)
        {
            GameObject obj = Instantiate(Resources.Load("iconCard") as GameObject, transform.GetChild(2).transform);

            var label = obj.transform.GetChild(0).GetComponent<TMP_Text>();
            label.text = o.OptionName;

            var icon = obj.GetComponent<RawImage>();
            icon.texture = Resources.Load(o.OptionIcon) as Texture;

            obj.GetComponent<Button>().onClick.AddListener(() =>
            {
                o.OptionAction();
            });
        }

    }

    internal void ShowInstructions(string textInstructions, string audioPath)
    {
        player.transform.parent.gameObject.SetActive(false);
        instructionText .text = textInstructions;
        var audioClip = Resources.Load(audioPath) as AudioClip;
        audioSource = instructionText.gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip ;
        audioSource.Play();
        instructionText.gameObject.SetActive(true);

    }
    internal void PlayVideo(string videoPath)
    {
        instructionText.gameObject.SetActive(false);
        var vidClip = Resources.Load(videoPath) as VideoClip;

        player.transform.parent.gameObject.SetActive(true);
        player.clip = vidClip;

        player.Play();
        player.loopPointReached += LoadEnd;

    }

    private void LoadEnd(VideoPlayer source)
    {
        SceneManager.LoadScene("Scene02");
    }

    private void GetOptions(ARObjectTracked tracked)
    {
        options = tracked.options;
    }
}
