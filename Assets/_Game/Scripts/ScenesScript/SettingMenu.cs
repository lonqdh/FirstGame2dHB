using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] private Button backBtn;
    [SerializeField] private Slider volumnSlider;
    [SerializeField] private GameObject settingMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] AudioMixer audioMixer;

    private void Start()
    {
        settingMenu.SetActive(true);

        backBtn.onClick.AddListener(BackButtonOnClick);
        volumnSlider.onValueChanged.AddListener(SetVolumn);

    }

    private void BackButtonOnClick()
    {
        settingMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void SetVolumn(float volumn)
    {
        audioMixer.SetFloat("masterVolumn", volumn);
    }
}
