using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager), typeof(ARRaycastManager))]
public class PlaceObject : MonoBehaviour
{
    [SerializeField] private GameObject toPlacePrefab;
    [SerializeField] private float minimumLength = 1.0f;
    [SerializeField] private float minimumBreadth = 1.0f;
    [SerializeField] private TMP_Text uiText;

    private ARPlaneManager arPlaneManager;
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> aRRaycastHits = new List<ARRaycastHit>();

    private void Awake()
    {
        arPlaneManager = GetComponent<ARPlaneManager>();
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    private void OnEnable()
    {
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    private void OnDisable()
    {
        arPlaneManager.planesChanged -= OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs eventArgs)
    {
        foreach (var addedPlane in eventArgs.added)
        {
            CheckPlaneSize(addedPlane);
        }
    }

    private void CheckPlaneSize(ARPlane plane)
    {
        Vector3 planeSize = plane.size; // Get the extents of the plane

        if (planeSize.x >= minimumLength && planeSize.y >= minimumBreadth)
        {
            uiText.text = "Info:" + "Plane meets the minimum size requirement.";
            SpawnKleen();

        }
        else
        {
            uiText.text = "Info:" + "Plane does not meet the minimum size requirement.";
        }

    }

    private void SpawnKleen()
    {
        GameObject obj = Instantiate(toPlacePrefab);
        Vector3 pos = obj.transform.position;
        Vector3 camPos = Camera.main.transform.position;
        Vector3 direction = camPos - pos;

        Vector3 targetRotEuler = Quaternion.LookRotation(direction).eulerAngles;
        Vector3 scaledEuler = Vector3.Scale(targetRotEuler, obj.transform.up.normalized);
        Quaternion targetRot = Quaternion.Euler(scaledEuler);
        obj.transform.rotation *= targetRot;
    }

}
