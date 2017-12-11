using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRS : MonoBehaviour {

    [Tooltip("Speed Limit")]
    public float SpeedLimit = 50f;

    [Tooltip("GameObject to use as blocking Wall")]
    public GameObject Wall = null;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (Wall && collision.gameObject.tag == "Player")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb && rb.velocity.x * 10 > SpeedLimit)
            {
                Wall.SetActive(true);
            }
        }
    }


    private void Awake()
    {
		if (Wall == null)
        {
            Debug.LogError("<color='Red'>No Wall given</color>", this);
        }
        else
        {
            Wall.SetActive(false);
        }
	}

}
