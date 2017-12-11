using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLimits : MonoBehaviour {

    [Tooltip("Menu In Game")]
    public MenuInGame MIG = null;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        string gOTag = collision.gameObject.tag;

        if (gOTag == "Player")
        {
            MIG.GameOver(null);
        }
        else if (gOTag == "Payload")
        {
            MIG.GameOver("Vous avez perdu votre chargement");
        }
    }


    private void Awake()
    {
	    if (MIG == null)
        {
            Debug.LogError("<color='Red'>No Menu In Game given</color>", this);
        }
	}
}
