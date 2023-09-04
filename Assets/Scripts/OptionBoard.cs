using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class OptionBoard : MonoBehaviour
{
    private Canvas optionBoardCanvas;
    private IARObjectOptions[] options;
    [SerializeField] private VideoPlayer player;

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
            GameObject obj = Instantiate(Resources.Load("iconCard") as GameObject, transform.GetChild(1).transform);

            var label = obj.transform.GetChild(0).GetComponent<TMP_Text>();
            label.text = o.OptionName;
            
            var desc = obj.transform.GetChild(1).GetComponent<TMP_Text>();
            desc.text = o.OptionDescription;

            var icon = obj.GetComponent<RawImage>();
            icon.texture = Resources.Load(o.OptionIcon) as Texture;

            obj.GetComponent<Button>().onClick.AddListener(() =>
            {
                o.OptionAction();
            });
        }
    }


    internal void PlayVideo(string videoPath)
    {
        var vidClip = Resources.Load(videoPath) as VideoClip;

        player.transform.parent.gameObject.SetActive(true);
        player.clip = vidClip;

        player.Play();

    }

    private void GetOptions(ARObjectTracked tracked)
    {
        options = tracked.options;
    }
}
