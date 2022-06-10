using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private static Screens gameState;
    public static Screens GameState { get => gameState; }
    private void Awake()
    {
        gameState = Screens.Menu;

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

    public void StartGame()
    {
        Person.animationState.Invoke(AnimationState.Running);
        gameState = Screens.InGame;
    }
    public void HandleFailing()
    {
        gameState = Screens.Fail;
        Person.animationState.Invoke(AnimationState.Idle);
        StartCoroutine(UIManager.instance.OpenFailScreen());     
    }
    public void StartPaintingStage()
    {
        gameState = Screens.Final;
        Person.animationState.Invoke(AnimationState.Idle);
        CameraController.instance.SetCameraToPaintingStage();
    }
    public void HandleWinning()
    {
        UIManager.instance.OpenWinScreen();
        gameState = Screens.Success;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
