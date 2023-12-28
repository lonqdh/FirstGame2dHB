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
    public Player player;
    private GameObject level;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void SetData(int id)
    {
        levelText.text = id.ToString();
        levelButton.onClick.AddListener(() => LevelButtonOnClick(id));
    }

    private void LevelButtonOnClick(int id)
    {
        level = Resources.Load<GameObject>("Level" + id);
        Instantiate(level);
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
        menu.SetActive(false);
    }
}

