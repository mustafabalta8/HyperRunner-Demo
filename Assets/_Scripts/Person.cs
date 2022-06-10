using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Person : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected Rigidbody rigidbody;
    [SerializeField] protected float sideMovementLimit;

    public Vector3 movementDirection;

    public static Action<AnimationState> animationState;
    private void OnEnable()
    {
        animationState += UpdateAnimationState;
    }
    private void OnDisable()
    {
        animationState -= UpdateAnimationState;
    }
    protected void UpdateAnimationState(AnimationState state)
    {
        switch (state)
        {
            case AnimationState.Idle:
                animator.SetBool("isRunning", false);
                break;
            case AnimationState.Running:
                animator.SetBool("isRunning", true);
                break;
                /*
            case AnimationState.Falling:
                animator.SetTrigger("isCollided");
                break;*/
        }
    }
    public virtual void CollideWithObstacle()
    {
        //
    }
}
