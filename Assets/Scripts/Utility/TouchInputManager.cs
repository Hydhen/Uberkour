using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage Touches on screen and message the collided object
/// </summary>
public class TouchInputManager : MonoBehaviour
{

    void Update()
    {

#if UNITY_EDITOR
        if (Input.GetMouseButton(0) || Input.GetMouseButtonUp(0) || Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, LayerMask.GetMask("TouchInput")))
            {
                GameObject target = hit.transform.gameObject;

                if (Input.GetMouseButtonDown(0))
                {
                    target.SendMessage("OnTouchDown", hit, SendMessageOptions.DontRequireReceiver);
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    target.SendMessage("OnTouchUp", hit, SendMessageOptions.DontRequireReceiver);
                }
                else if (Input.GetMouseButton(0))
                {
                    target.SendMessage("OnTouchStay", hit, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
#endif

        foreach (Touch touch in Input.touches)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, LayerMask.GetMask("TouchInput")))
            {
                GameObject target = hit.transform.gameObject;

                if (touch.phase == TouchPhase.Began)
                {
                    target.SendMessage("OnTouchDown", hit, SendMessageOptions.DontRequireReceiver);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    target.SendMessage("OnTouchUp", hit, SendMessageOptions.DontRequireReceiver);
                }
                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    target.SendMessage("OnTouchStay", hit, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}