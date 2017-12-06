using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ApplyForcesToObject : MonoBehaviour {

    [Tooltip("Force to apply")]
    public float Force = 5;

    private Rigidbody2D Rb = null;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    private void Update ()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D))
        {
            Debug.Log("Apply force " + -Force + " to " + Rb.gameObject);
            Rb.AddForce(new Vector2(-Force, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Apply force " + Force + " to " + Rb.gameObject);
            Rb.AddForce(new Vector2(Force, 0));
        }
	}
}
