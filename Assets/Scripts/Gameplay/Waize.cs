using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waize : MonoBehaviour {

    [Tooltip("Waize UI")]
    public GameObject WaizeUI = null;

    [Tooltip("If checked, will activate WaizeUI on Trigger")]
    public bool Visible = false;


	private void Awake()
    {
        if (WaizeUI == null)
        {
            Debug.LogError("<color='Red'>No Waize UI given</color>", this);
        }
        else
        {
            WaizeUI.SetActive(false);
        }
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CRS")
        {
            WaizeUI.SetActive(Visible);
        }
    }
}
