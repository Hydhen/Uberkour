using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorials : MonoBehaviour {

    [Tooltip("The whole Tutorial GUI Object")]
    public GameObject TutorialGameObject = null;

    [Tooltip("The Button that pass to the next Tutorial")]
    public Button NextButton = null;

    [Tooltip("Stuff to disable during the Tutorial, will be re-enable after")]
    public GameObject[] ObjectToDisable = null;

    [Tooltip("List of Tutorials to show")]
    public Tutorial[] Tutos = null;


    private int Index = 0;

    private float LastTimeScale = 0f;

    private Text NextButtonText = null;


    public void OnNextButtonPressed()
    {
        Tutos[Index++].Hide();

        if (Index < Tutos.Length)
        {
            if (Index == Tutos.Length - 1 && NextButtonText)
            {
                NextButtonText.text = "Terminer";
            }

            Tutos[Index].Show();
        }
        else
        {
            NextButton.gameObject.SetActive(false);
            TutorialGameObject.SetActive(false);
            Time.timeScale = LastTimeScale;

            if (ObjectToDisable.Length != 0)
            {
                for (int i = 0; i < ObjectToDisable.Length; i++)
                {
                    ObjectToDisable[i].SetActive(true);
                }
            }
        }
    }


    private void Awake()
    {
        if (TutorialGameObject == null)
        {
            Debug.LogError("<color='Red'>No Tutorial GameObject given</color>");
        }

        if (NextButton == null)
        {
            Debug.LogError("<color='Red'>No Next Button given</color>");
        }
        else 
        {
            NextButtonText = NextButton.GetComponentInChildren<Text>();

            if (NextButtonText == null)
            {
                Debug.LogError("<color='Red'>No Next Button Text found</color>");
            }
        }

        if (Tutos.Length > 0)
        {
            for (int i = 0; i < Tutos.Length; i++)
            {
                Tutos[i].Hide();
            }
        }
    }

    private void Start()
    {
        if (Tutos.Length != 0)
        {
            LastTimeScale = Time.timeScale;
            Time.timeScale = 0;

            if (Tutos.Length == 1 && NextButtonText)
            {
                NextButtonText.text = "Terminer";
            }

            Tutos[Index].Show();
        }

        if (ObjectToDisable.Length != 0)
        {
            for (int i = 0; i < ObjectToDisable.Length; i++)
            {
                ObjectToDisable[i].SetActive(false);
            }
        }
    }

}
