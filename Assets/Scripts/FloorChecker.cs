using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FloorChecker : MonoBehaviour
{
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private GameObject floorMeshPrefab;
    public GameObject ball;

    private void OnEnable()
    {
        planeManager.planesChanged += OnPlanesChanged;
        Debug.Log("Enabled");
    }

    private void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs eventArgs)
    {
        Debug.Log("Plane Changed");
        Instantiate(ball, eventArgs.added.First().transform.position, Quaternion.identity);

        foreach (var addedPlane in eventArgs.added)
        {
            if (IsFloorRectangle(addedPlane))
            {
                VisualizeFloor(addedPlane);
                break; // Visualize only once when a suitable floor is detected
            }
        }
    }

    private bool IsFloorRectangle(ARPlane plane)
    {
        // Implement your logic to determine if the plane resembles a floor rectangle
        // This could involve checking the plane's size and orientation
        // Return true if it's a suitable floor, false otherwise
        return true; // For demonstration purposes, assuming all detected planes are suitable
    }

    private void VisualizeFloor(ARPlane plane)
    {
        Debug.Log("Called Visualize");
        if (floorMeshPrefab != null)
        {
            GameObject floorMeshObject = Instantiate(floorMeshPrefab, plane.center, Quaternion.identity);

            // Scale the floor mesh object based on your desired dimensions
            Vector3 scale = new Vector3(plane.size.x * 1.5f, 0.01f, plane.size.y * 1.5f);
            floorMeshObject.transform.localScale = scale;
        }
    }
}
