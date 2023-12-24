using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    [SerializeField] private LevelData levelData;
    [SerializeField] private LevelButton levelPrefab;
    [SerializeField] private Transform levelItemParent;
    [SerializeField] private GameObject menu;

    private void Start()
    {
        SpawnLevel();
    }

    private void SpawnLevel()
    {
        for(int i = 0; i < levelData.levelItems.Count; i++)
        {
            LevelButton levelButton = Instantiate(levelPrefab, levelItemParent);
            levelButton.SetData(levelData.levelItems[i].levelId);
            levelButton.menu = this.menu;
        }
    }





    //[SerializeField] private Button level;
    //[SerializeField] private GameObject levelmapprefab;
    //[SerializeField] private GameObject menu;

    //private void Start()
    //{
    //    level.onClick.AddListener(LoadLevel);
    //}

    //public void LoadLevel()
    //{
    //    menu.SetActive(false);
    //    Instantiate(levelmapprefab);
    //}

}
