using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target; // 'G' in GameObject should be capitalized
    public float xOffset, yOffset, zOffset;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + new Vector3(xOffset, yOffset, zOffset);
        transform.LookAt(target.transform.position); // 'A' in LookAt should be capitalized, and 'position' is spelled with two 'i's
    }
}
