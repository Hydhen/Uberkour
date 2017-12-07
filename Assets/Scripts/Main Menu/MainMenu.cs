using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [Tooltip("Menu selection")]
    public GameObject Main = null;

    [Tooltip("Level selection")]
    public GameObject Levels = null;


    #region Public Methods

    public void OnPlayButtonPressed()
    {
        Main.SetActive(false);
        Levels.SetActive(true);
    }

    public void OnBackButtonPressed()
    {
        Levels.SetActive(false);
        Main.SetActive(true);
    }

    public void OnLevelButtonPressed()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        SceneManager.LoadScene(EventSystem.current.currentSelectedGameObject.name.ToString());
    }

    #endregion


    #region Private Methods

    private void Awake()
    {
        if (Main == null || Levels == null)
        {
            Debug.LogError("<color='Red'>No Main menu or Level menu</color>");
        }
    }

    private void Start()
    {
        if (Levels)
        {
            Levels.SetActive(false);
        }
    }

    #endregion

}
