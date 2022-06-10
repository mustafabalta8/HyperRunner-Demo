using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Person
{
    [Header("Movement")]
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float swerveSpeed;

    // input data
    private float lastFrameFingerPositionX;
    private float moveFactorX;

    public static PlayerController instance;

    private void Awake()
    {
        Singelton();
       
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
    private void Update()
    {
        if (GameManager.GameState == Screens.InGame)
        {
            HandleSideMovement();
            MoveForward();
        }
    }

    public override void CollideWithObstacle()
    {
        animator.SetTrigger("isCollided");
        GameManager.instance.HandleFailing();
    }


    private void MoveForward()
    {
        transform.Translate(movementDirection * Time.deltaTime * forwardSpeed);
    }
    private void HandleSideMovement()
    {
        GetInput();

        float swerveAmount = swerveSpeed * moveFactorX * Time.deltaTime;
        var currentPos = transform.position; 
        currentPos.x += swerveAmount;
        currentPos.x = Mathf.Clamp(currentPos.x, -sideMovementLimit, sideMovementLimit);

        transform.position = currentPos;
        
    }
    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }
    }
}
