using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
public class Pickup : MonoBehaviour {

    private AudioSource AS = null;

    private Rigidbody2D RB = null;


    public void StopSound()
    {
        AS.Stop();
    }


    private void Awake()
    {
        AS = GetComponent<AudioSource>();
        RB = GetComponent<Rigidbody2D>();
	}
	
	private void FixedUpdate()
    {
        AS.pitch = (RB.velocity.x / 4);

        if (AS.pitch < 0)
        {
            AS.pitch *= -1;
        }

        if (AS.pitch > 3)
        {
            AS.pitch = 3;
        }
    }
}
