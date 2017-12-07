using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SpeedCounter : MonoBehaviour {

    [Tooltip("Target to Track")]
    public GameObject Target = null;


    private Rigidbody2D Rb = null;

    private Text Counter = null;


	private void Awake()
    {
        Counter = GetComponent<Text>();

		if (Target)
        {
            Rb = Target.GetComponent<Rigidbody2D>();

            if (Rb == null)
            {
                Debug.LogError("<color='Red'>No Rigidibody attached to Target: </color>" + Target, this);
            }
        }
        else
        {
            Debug.LogError("<color='Red'>No Target</color>", this);
        }
	}
	
	private void Update()
    {
		if (Rb)
        {
            Counter.text = ((int)((Rb.velocity.x) * 10)).ToString();
        }
	}
}
