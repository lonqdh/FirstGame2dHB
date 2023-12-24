using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Button levelButton;
    public GameObject menu;
    private GameObject level;


    public void SetData(int id)
    {
        levelText.text = id.ToString();
        levelButton.onClick.AddListener(() => LevelButtonOnClick(id));
    }

    private void LevelButtonOnClick(int id)
    {
        level = Resources.Load<GameObject>("Level" + id);
        Instantiate(level);
        menu.SetActive(false);
    }
}

