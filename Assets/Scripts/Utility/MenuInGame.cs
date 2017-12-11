using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInGame : MonoBehaviour {

    [Tooltip("Check if this is the Last Level")]
    public bool IsLastLevel = true;

    [Tooltip("Button will be disabled for the Last Level")]
    public Button NextLevelButton = null;

    [Tooltip("Menu GameObject")]
    public GameObject Menu = null;

    [Tooltip("UI GameObject")]
    public GameObject UI = null;

    [Tooltip("Menu In Game GameObject")]
    public GameObject InGameMenu = null;

    [Tooltip("End Menu GameObject")]
    public GameObject EndMenu = null;

    [Tooltip("GameOver Menu GameObject")]
    public GameObject GameOverMenu = null;


    private float LastTimeScale = 0;


    #region Public Methods

    #region Button Management

    public void OnMenuButtonPressed()
    {
        InGameMenu.SetActive(false);
        UI.SetActive(false);
        Menu.SetActive(true);
        LastTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    public void OnRetryButtonPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnBackButtonPressed()
    {
        Menu.SetActive(false);
        UI.SetActive(true);
        InGameMenu.SetActive(true);
        Time.timeScale = LastTimeScale;
    }

    public void OnQuitButtonPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    public void OnNextLevelButtonPressed()
    {
        if (IsLastLevel == false)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    #endregion


    public void EndLevel()
    {
        LastTimeScale = Time.timeScale;
        Time.timeScale = 0;
        UI.SetActive(false);
        InGameMenu.SetActive(false);
        EndMenu.SetActive(true);
    }

    public void GameOver()
    {
        LastTimeScale = Time.timeScale;
        Time.timeScale = 0;
        UI.SetActive(false);
        InGameMenu.SetActive(false);
        GameOverMenu.SetActive(true);
    }

    #endregion


    #region Private Methods

    private void Awake()
    {
        if (Menu == null)
        {
            Debug.LogError("<color='Red'>No Menu given</color>");
        }

        if (UI == null)
        {
            Debug.LogError("<color='Red'>No UI given</color>");
        }

        if (InGameMenu == null)
        {
            Debug.LogError("<color='Red'>No In Game Menu given</color>");
        }

        if (EndMenu == null)
        {
            Debug.LogError("<color='Red'>No End Menu given</color>");
        }

        if (NextLevelButton && IsLastLevel)
        {
            NextLevelButton.interactable = false;
        }
    }

    private void Start()
    {
        if (Menu)
        {
            Menu.SetActive(false);
        }

        if (EndMenu)
        {
            EndMenu.SetActive(false);
        }

        if (GameOverMenu)
        {
            GameOverMenu.SetActive(false);
        }
    }

    #endregion	
}
