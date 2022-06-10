using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Opponent"))
        {
            //print(other.gameObject + "is triggered by obstacle");
            other.GetComponent<Person>().CollideWithObstacle();
        }
    }
}
