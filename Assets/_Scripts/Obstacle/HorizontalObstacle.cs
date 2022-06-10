using UnityEngine;

public class HorizontalObstacle : Obstacle
{
    //[SerializeField] private float moveRange = 6;
    
    [SerializeField] private Vector3 movementLimit;
    [SerializeField] private float moveSpeed = 3;
    private enum MovementDirection
    {
        Right,
        Left
    }

    [SerializeField] private MovementDirection moveDirection;
    void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        //transform.position = new Vector3(Mathf.PingPong(Time.time, moveRange), transform.position.y, transform.position.z);

        if (moveDirection == MovementDirection.Right && transform.localPosition.x < movementLimit.x)
        {
            transform.localPosition += Vector3.right * Time.deltaTime * moveSpeed;
            
        }
        else
        {
            moveDirection = MovementDirection.Left;
        }

        if (moveDirection == MovementDirection.Left && transform.localPosition.x > 0)
        {
            transform.localPosition += Vector3.left * Time.deltaTime * moveSpeed;

        }
        else
        {
            moveDirection = MovementDirection.Right;
        }


    }
}
