using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    void Update()
    {
        // Move the camera to the specified position
        transform.position = cameraPosition.position;
    }
}
