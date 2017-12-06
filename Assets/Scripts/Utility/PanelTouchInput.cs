using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle touch of a panel
/// </summary>
public class PanelTouchInput : MonoBehaviour {

    [Tooltip("Enable the Renderer when it has been Touched")]
    public bool DebugRenderer = true;

    [Tooltip("Object to apply Force")]
    public GameObject Target = null;

    [Tooltip("Amount of force to apply")]
    public float Force = 5f;

    [Tooltip("Maximum Acceleration from Input")]
    public float MaxUserAcceleration = 5f;


    private MeshRenderer Renderer = null;

    private float Acceleration = 0f;


    #region Public Methods

    public void OnTouchDown()
    {
        if (DebugRenderer)
        {
            Renderer.enabled = true;
        }

        if (Target)
        {
            Rigidbody2D rb = Target.GetComponent<Rigidbody2D>();

            if (rb)
            {
                rb.AddForce(new Vector2(Force, 0));
            }
            else
            {
                Debug.LogWarning("No Rigidbody2D on Target: " + Target);
            }
        }
    }

    public void OnTouchUp()
    {
        if (DebugRenderer)
        {
            Renderer.enabled = false;
            Acceleration = 0f;
        }
    }

    public void OnTouchStay()
    {
        if (Target)
        {
            Rigidbody2D rb = Target.GetComponent<Rigidbody2D>();

            if (rb)
            {
                rb.AddForce(new Vector2(Force * Time.deltaTime + Acceleration, 0));
                if (MaxUserAcceleration < 0f)
                {                    
                    Acceleration -= 0.1f;
                }
                else
                {
                    Acceleration += 0.1f;
                }
            }
            else
            {
                Debug.LogWarning("No Rigidbody2D on Target: " + Target);
            }
        }
    }

    #endregion


    #region Private Methods

    private void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();

        if (Target == null)
        {
            Debug.LogError("<color='Red'>No Target</color>", this);
        }
    }

    #endregion

}
