using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float lerpValue;
    private Vector3 offset;
    [SerializeField] private Vector3 paintingStageOffset;

    public static CameraController instance;
    private void Start()
    {
        Singelton();
        offset = transform.position - target.position;
    }
    private void LateUpdate()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue * Time.deltaTime);
    }
    public void SetCameraToPaintingStage()
    {
        target.position = new Vector3(0, target.position.y, target.position.z);
        //transform.position = new Vector3(0, transform.position.y, transform.position.z);
        offset = paintingStageOffset;    
        transform.Rotate(Vector3.right * -10);
        lerpValue = 5;
    }
    private void Singelton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
