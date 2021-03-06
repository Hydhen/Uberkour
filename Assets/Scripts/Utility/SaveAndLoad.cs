﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveAndLoad : MonoBehaviour {

    [Tooltip("Number of Level")]
    public int NumberOfLevels = 2;

    [HideInInspector]
    public static SaveAndLoad Instance = null;


    private string SaveFileName = "/save.json";

    private GameData Data = null;


    static public SaveAndLoad GetInstance()
    {
        return Instance;
    }

    public int GetProgression()
    {
        return Data.Progression;
    }

    public void SetLevelDone(int Index)
    {
        if (Index > Data.Progression)
        {
            Data.Progression = Index;
        }

        SaveData();
    }

    public int GetNumberOfLevels()
    {
        return NumberOfLevels;
    }


    private bool LoadData()
    {
        string filePath = Application.persistentDataPath + SaveFileName;

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            Data = JsonUtility.FromJson<GameData>(dataAsJson);

            Debug.Log("Loaded: " + dataAsJson);

            return true;
        }

        Data = new GameData();
        Data.Progression = 0;

        return false;
    }

    private void SaveData()
    {
        string dataAsJson = JsonUtility.ToJson(Data);
        string filePath = Application.persistentDataPath + SaveFileName;

        File.WriteAllText(filePath, dataAsJson);

        Debug.Log("Saved: " + dataAsJson);
    }

	private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        Debug.Log("Save file: " + Application.persistentDataPath + SaveFileName);

        DontDestroyOnLoad(gameObject);

        if (LoadData() == false)
        {
            Debug.Log("Save file created");
            SaveData();
        }
        else
        {
            Debug.Log("Existing save file used");
        }
    }
}
