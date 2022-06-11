using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonutObstacle : Obstacle
{
    [SerializeField] private Vector3 movementVector;
    [SerializeField] [Range(0, 1)] private float movementFactor;
    [SerializeField] private float speed = 1f;

    private float period = 2f;
    private Vector3 startingPos;
    private const float tau = Mathf.PI * 2f; // constant value of 6.283 -> full circle
    void Start()
    {
        startingPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (period <= Mathf.Epsilon) { return; }// instead of 0, I used Mathf.Epsilon
        float cycles = Time.time * speed / period; //continiously growing over time

        float rawSinWave = Mathf.Sin(cycles);//* tau//going from -1 to 1 
        movementFactor = (rawSinWave + 1) / 2f; //recalculated to go from 0 to 1


        transform.position = Vector3.Lerp(startingPos, startingPos + movementVector, movementFactor);

        //Vector3 offset = movementVector * movementFactor;
        //transform.position = startingPos + offset;
    }
}
