using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformObstacle : MonoBehaviour
{
    [SerializeField] private int rotationSpeed = 90;
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
