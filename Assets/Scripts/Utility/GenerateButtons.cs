using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(RectTransform))]
public class GenerateButtons : MonoBehaviour {

    [Tooltip("Height of a Button")]
    public float ButtonHeight = 120f;

    [Tooltip("Width of a Button")]
    public float ButtonWidth = 120f;

    [Tooltip("Space between 2 Buttons")]
    public float ButtonMargin = 10f;

    [Tooltip("Number of Levels")]
    public int NumberOfLevel = 2;

    [Tooltip("Sprite to use for Button")]
    public Sprite ButtonSprite = null;

    [Tooltip("Object containing Callback to use for OnClick() on the Button")]
    public MainMenu mainMenu = null;


    private RectTransform RT = null;

    private float HorizontalPadding = 0f;

    private float VerticalPadding = 0f;

    private int HorizontalMaxButtons = 0;

    private int VerticalMaxButtons = 0;


    private GameObject CreateLabel(string label)
    {
        GameObject gO = new GameObject();

        gO.name = label + " label";

        RectTransform rT = gO.AddComponent<RectTransform>();
        gO.AddComponent<CanvasRenderer>();
        Text text = gO.AddComponent<Text>();

        rT.anchorMin = new Vector2(0, 0);
        rT.anchorMax = new Vector2(1, 1);

        text.text = label;
        text.fontSize = 42;
        text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        text.color = Color.black;
        text.alignment = TextAnchor.MiddleCenter;

        return gO;
    }

    private GameObject CreateButton(string label)
    {
        GameObject gO = new GameObject();

        RectTransform rT = gO.AddComponent<RectTransform>();
        gO.AddComponent<CanvasRenderer>();
        Image image = gO.AddComponent<Image>();
        Button button = gO.AddComponent<Button>();

        gO.transform.SetParent(gameObject.transform, false);

        rT.sizeDelta = new Vector2(ButtonWidth, ButtonHeight);

        if (ButtonSprite)
        {
            image.overrideSprite = ButtonSprite;
        }

        if (mainMenu)
        {
            button.onClick.AddListener(mainMenu.OnLevelButtonPressed);
        }

        GameObject text = CreateLabel(label);

        text.transform.SetParent(gO.transform);
        text.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

        return gO;
    }

    private void GenerateButtonLoop()
    {
        int row = 0;
        int col = 0;

        for (int i = 0; i < NumberOfLevel; i++)
        {
            GameObject gO = CreateButton((i + 1).ToString());

            gO.name = (i + 1).ToString();

            float posX = -(RT.rect.width / 2) + (col * ButtonWidth)
                + (col - 1) * ButtonMargin + HorizontalPadding / 2 + ButtonWidth / 2;
            float posY = (RT.rect.height / 2) - (row * ButtonHeight)
                - (row - 1) * ButtonMargin - VerticalPadding / 2 - ButtonHeight / 2;

            gO.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, posY);


            if (col >= HorizontalMaxButtons - 1)
            {
                col = 0;
                ++row;
            }
            else
            {
                col++;
            }
        }
    }

    private void Awake()
    {
        RT = GetComponent<RectTransform>();

        if (mainMenu == null)
        {
            Debug.LogError("<color='Red'>No Main Menu given</color>");
        }
    }

	private void Start()
    {
        HorizontalMaxButtons = (int)(RT.rect.width / (ButtonWidth + ButtonMargin));
        HorizontalPadding = RT.rect.width % (ButtonWidth + ButtonMargin);

        VerticalMaxButtons = (int)(RT.rect.height / (ButtonHeight + ButtonMargin));
        VerticalPadding = RT.rect.height % (ButtonHeight + ButtonMargin);

        Debug.Log("Horizontal Buttons: " + HorizontalMaxButtons + " with Padding of " + (HorizontalPadding + ButtonMargin) / 2 + " and Margin of " + ButtonMargin);
        Debug.Log("Vertical Buttons: " + VerticalMaxButtons + " with Padding of " + (VerticalPadding + ButtonMargin) / 2 + " and Margin of " + ButtonMargin);

        Debug.Log(RT.pivot);

        GenerateButtonLoop();
   	}
	
}
