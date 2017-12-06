using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class TargetCamera : MonoBehaviour {

    [Tooltip("Target to follow")]
    public GameObject Target = null;

    [Tooltip("Speed of the Camera")]
    public float Speed = 5f;

    [Tooltip("Offset to apply to Camera position")]
    public Vector3 PositionOffset = new Vector3(6f, 0, -10f);
        
    private void Awake()
    {
		if (Target == null)
        {
            Debug.LogError("<color='Red'>No Target to follow</color>", this);
        }
	}

    private void FixedUpdate()
    {
        if (Target != null)
        {
            // Get new position
            Vector3 newPosition = Target.transform.position + PositionOffset;

            // Lerp to this position
            transform.position = Vector3.Lerp(transform.position, newPosition, Speed * Time.fixedDeltaTime);
        }
	}
}
