using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    public Transform Player;
    public Transform cameraLocation;
    void Update()
    {
        cameraLocation.position = Player.position + offset;
    }
}
