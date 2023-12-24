using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject welcomeMenu;
    [SerializeField] private Button backBtn;

    private void Start()
    {
        welcomeMenu.SetActive(true);

        backBtn.onClick.AddListener(BackBtnOnClick);

    }

    private void BackBtnOnClick()
    {
        welcomeMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
