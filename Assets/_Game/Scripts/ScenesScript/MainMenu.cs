using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startBtn;
    [SerializeField] private Button settingBtn;
    [SerializeField] private Button welcomeBtn;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingMenu;
    [SerializeField] private GameObject welcomeMenu;
    [SerializeField] private GameObject levelMenu;

    void Start()
    {
        mainMenu.SetActive(true);

        startBtn.onClick.AddListener(LevelMenu);
        //startBtn.onClick.AddListener(StartGame);
        settingBtn.onClick.AddListener(SettingOnClick);
        welcomeBtn.onClick.AddListener(WelcomeOnClick);
    }

    private void LevelMenu()
    {
        levelMenu.SetActive(true);
        mainMenu.SetActive(false);

    }


    private void SettingOnClick()
    {
        mainMenu.SetActive(false);
        settingMenu.SetActive(true);
    }
    
    private void WelcomeOnClick()
    {
        mainMenu.SetActive(false);
        welcomeMenu.SetActive(true);
    }

}
