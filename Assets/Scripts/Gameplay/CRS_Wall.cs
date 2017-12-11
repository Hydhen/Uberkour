using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRS_Wall : MonoBehaviour {

    [Tooltip("Menu In Game")]
    public MenuInGame MIG = null;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (MIG && collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("StopSound", null, SendMessageOptions.DontRequireReceiver);
            MIG.GameOver(null);
        }
    }


    private void Awake()
    {
        if (MIG == null)
        {
            Debug.LogError("<color='Red'>No Menu In Game given</color>");
        }
    }

}
