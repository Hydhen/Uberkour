using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour {

    [Tooltip("Force to apply as a Boost")]
    public float Force = 5f;


    public void OnTriggerStay2D(Collider2D collision)
    {
        GameObject gO = collision.gameObject;

        if (gO.tag == "Player")
        {
            gO.GetComponent<Rigidbody2D>().AddForce(new Vector2(Force * Time.deltaTime, 0f));
        }
    }

}
