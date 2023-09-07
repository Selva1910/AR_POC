using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public abstract class ARObjectTracked : MonoBehaviour
{
    [SerializeField] public Vector3 offset;

    public abstract string objectName { get; }
    public abstract IARObjectOptions[] options { get; }

    public event Action<ARObjectTracked> OnARObjectEnable;

    public void PerformOptionAction(int optionIndex)
    {
        if (optionIndex >= 0 && optionIndex < options.Length)
        {
            options[optionIndex].OptionAction();
        }
        else
        {
            Debug.LogWarning("Invalid optionIndex");
        }
    }

    public GameObject spawnedPrefab;

    private void Start()
    {
        spawnedPrefab = Instantiate(Resources.Load("VideoUIPrefab"), transform.position + offset, Quaternion.identity, this.transform) as GameObject;
        //var rotationDifference = Camera.main.transform.eulerAngles - transform.eulerAngles;
        //spawnedPrefab.transform.Rotate(rotationDifference);
    }
    private void Update()
    {
        if (spawnedPrefab == null)
            return;

        spawnedPrefab.transform.position = transform.position + offset;
    }

}


public struct ARObjectOptions : IARObjectOptions
{
    public string OptionName { get; private set; }
    public Action OptionAction { get; private set; }
    public string OptionIcon { get; private set; }
    public ARObjectOptions(string name, string iconPath, Action action)
    {
        OptionName = name;
        OptionIcon = iconPath;
        OptionAction = action;
    }

    public void PerformOptionAction()
    {
        if (OptionAction != null)
        {
            OptionAction.Invoke(); // Invoke the assigned function for this option
        }
        else
        {
            Debug.LogWarning($"No action defined for option: {OptionName}");
        }
    }
}

public interface IARObjectOptions
{
    string OptionName { get; }
    string OptionIcon { get; }
    Action OptionAction { get; }
}