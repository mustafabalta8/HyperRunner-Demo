using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private bool isPlayerPassed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isPlayerPassed) { return; }
            isPlayerPassed = true;
            
            GameManager.instance.StartPaintingStage();
        }
        if (other.CompareTag("Opponent"))
        {
            other.gameObject.SetActive(false);
        }

    }
}
