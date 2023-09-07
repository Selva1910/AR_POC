using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableScan : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(FindAnyObjectByType<ARObjectTracked>() == null)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
