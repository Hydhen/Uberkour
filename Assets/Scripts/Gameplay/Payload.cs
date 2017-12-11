using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Payload : MonoBehaviour {

    [Tooltip("Menu handler")]
    public MenuInGame MIG = null;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (MIG)
            {
                MIG.GameOver();
            }
            else
            {
                Debug.LogError("<color='Red'>No Menu Handler given, cannot loose</color>");
            }
        }
    }

}
