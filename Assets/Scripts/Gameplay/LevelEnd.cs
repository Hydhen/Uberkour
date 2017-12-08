using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

    [Tooltip("Game Manager")]
    public MenuInGame MIG = null;


    private SaveAndLoad SAL = null;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (MIG)
            {
                MIG.EndLevel();
            }

            if (SAL)
            {
                SAL.SetLevelDone(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }


    private void Awake()
    {
        SAL = GameObject.FindGameObjectWithTag("SaveAndLoad").GetComponent<SaveAndLoad>();
    }
}
