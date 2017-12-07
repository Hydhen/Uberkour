using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    [Tooltip("Title of the Tutorial")]
    public Text Title = null;

    [Tooltip("Content of the Tutorial")]
    public Text Content = null;


    public void Hide()
    {
        if (Title)
        {
            Title.gameObject.SetActive(false);
        }

        if (Content)
        {
            Content.gameObject.SetActive(false);
        }
    }

    public void Show()
    {
        if (Title)
        {
            Title.gameObject.SetActive(true);
        }

        if (Content)
        {
            Content.gameObject.SetActive(true);
        }
    }

    public void SetTitle(string newTitle)
    {
        if (Title)
        {
            Title.text = newTitle;
        }
    }

    public void SetContent(string newContent)
    {
        if (Content)
        {
            Content.text = newContent;
        }
    }
}
