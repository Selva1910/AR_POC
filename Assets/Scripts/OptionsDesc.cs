using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsDesc : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text desc;
    public void OnPointerEnter(PointerEventData eventData)
    {
        desc.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        desc.gameObject.SetActive(false);
    }
}
