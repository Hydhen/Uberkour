using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour {

    [Tooltip("Menu GameObject")]
    public GameObject Menu = null;

    [Tooltip("UI GameObject")]
    public GameObject UI = null;

    [Tooltip("Menu In Game GameObject")]
    public GameObject InGameMenu = null;


    private float LastTimeScale = 0;


    #region Public Methods

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    #endregion


    #region Private Methods

    private void Awake()
    {
        if (Menu == null)
        {
            Debug.LogError("<color='Red'>No Menu given</color>");
        }
    }

    private void Start()
    {
        if (Menu)
        {
            Menu.SetActive(false);
        }
    }

    #endregion	
}
