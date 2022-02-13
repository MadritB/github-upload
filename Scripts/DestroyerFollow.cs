using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerFollow : MonoBehaviour
{
    public Vector3 offset;
    public Transform playerTransform;
    public Transform destroyerTransform;
    // Update is called once per frame
    void Update()
    {
        destroyerTransform.position = playerTransform.position + offset;
    }
}
