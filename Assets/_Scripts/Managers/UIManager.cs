using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject failScreen;
    [SerializeField] private GameObject inGameScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject menuScreen;

    [SerializeField] private float failScreenOpeningDelay;
    private void Start()
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

    public void OpenWinScreen()
    {
        winScreen.SetActive(true);
        inGameScreen.SetActive(false);
    }
    public IEnumerator OpenFailScreen()
    {
        yield return new WaitForSeconds(failScreenOpeningDelay);
        failScreen.SetActive(true);
        inGameScreen.SetActive(false);
    }
}
