using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : Person
{
    [SerializeField] private int numberOfRays = 5;
    [SerializeField] private float rayAngle = 80;
    [SerializeField] private float rayLength = 2f;
    [SerializeField] private LayerMask obstacleMask;


    [SerializeField] private float forwardSpeed;
    [SerializeField] private float sideMovementSpeed;


    void FixedUpdate()
    {
        if (GameManager.GameState == Screens.InGame)
        {
            HandleMovement();

        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }      
    }
    
    private void HandleMovement()
    {
        RaycastHit raycastHit;
        for (int i = 0; i < numberOfRays; i++)
        {
            var rotation = transform.rotation;
            var rotationMod = Quaternion.AngleAxis((i / ((float)numberOfRays - 1)) * rayAngle * 2 - rayAngle, transform.up);
            var direction = rotation * rotationMod * Vector3.forward;
            //Debug.Log("direction: " + direction);

            Ray ray = new Ray(transform.position + transform.up, direction);
            if (Physics.Raycast(ray, out raycastHit, rayLength, obstacleMask))
            {
                Debug.DrawRay(transform.position + transform.up, direction * rayLength, Color.red, 0f);
                /*if (transform.position.x > -.5f && transform.position.x < .5f)
                {
                    float newPosition = Random.Range(Random.Range(-sideMovementLimit, -3.5f), Random.Range(3.5f, sideMovementLimit));
                    transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
                }*/
                if (transform.position.x <= 0)
                {
                    transform.position += Vector3.left * sideMovementSpeed * Time.fixedDeltaTime;
                }
                else if (transform.position.x > 0)
                {
                    transform.position += Vector3.right * sideMovementSpeed * Time.fixedDeltaTime;
                }

            }
            else
            {
                Debug.DrawRay(transform.position + transform.up, direction * rayLength, Color.green, 0f);
            }
        }
        if(transform.position.x > sideMovementLimit)
        {
            transform.position = new Vector3(1, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -sideMovementLimit)
        {
            transform.position = new Vector3(-1, transform.position.y, transform.position.z);
        }
        HandleForwardMovement();
    }

    private void HandleForwardMovement()
    {
        rigidbody.velocity = movementDirection * forwardSpeed;
    }

    public override void CollideWithObstacle()
    {
        transform.position = Vector3.zero;
        //print("opponent is collide with an obstacle");
    }
}
