using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Text HighScore;
    public GameObject settings;
    public GameObject UIPlayBtn;
    public Slider volumeSlider;
    private bool IsSettings = true;
    void Start()
    {
        HighScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        IsSettings = true;
        Settings();
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }
    public void Exitbutton()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1;
    }
    public void ChangeVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume",volume);
        AudioListener.volume = PlayerPrefs.GetFloat("Volume",1);
    }
    public void Settings()
    {
        IsSettings = !IsSettings;
        settings.SetActive(IsSettings);
        UIPlayBtn.SetActive(!IsSettings);
    }
}
