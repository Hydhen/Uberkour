﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

    [Tooltip("Game Manager")]
    public MenuInGame MIG = null;

    [Tooltip("Object that need to stop Sound")]
    public GameObject GameObjectToMute = null;


    private SaveAndLoad SAL = null;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameObjectToMute)
            {
                GameObjectToMute.SendMessage("StopSound", null, SendMessageOptions.DontRequireReceiver);
            }

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
        if (MIG == null)
        {
            Debug.LogError("<color='Red'>No Menu In Game given</color>");
        }

        SAL = SaveAndLoad.GetInstance();
    }
}
