using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScenesSystem : MonoBehaviour
{
    [SerializeField] private string newScene;
      
    private int deathCount = 0;
    public GameObject gameOverUI;
         
    public void NewGame()
    {
        SceneManager.LoadScene(newScene);
    }

    public void TurnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
        
    public void ExitGame()
    {
        Application.Quit();
    }
}
