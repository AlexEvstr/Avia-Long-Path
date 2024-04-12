using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _skinsPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _levelsPanel;

    [SerializeField] private GameObject _onBoard_1;
    [SerializeField] private GameObject _onBoard_2;
    [SerializeField] private GameObject _onBoard_3;

    private void OnEnable()
    {
        string firstEnter = PlayerPrefs.GetString("FirstEnter", "");
        if (firstEnter == "")
        {
            _onBoard_1.SetActive(true);
        }
    }

    private void Start()
    {
        Vibration.Init();
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void PlayButton()
    {
        if (SettingsButtons.CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
        int bestLevel = PlayerPrefs.GetInt("BestLevel", 1);
        PlayerPrefs.SetInt("Level", bestLevel);
        SceneManager.LoadScene("GameplayScene");
    }

    public void LevelsButton()
    {
        if (SettingsButtons.CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
        _levelsPanel.SetActive(true);
    }

    public void CloseLevels()
    {
        if (SettingsButtons.CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
        _levelsPanel.SetActive(false);
    }

    public void SkinsButton()
    {
        if (SettingsButtons.CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
        _skinsPanel.SetActive(true);
    }

    public void CloseSkinsPanel()
    {
        if (SettingsButtons.CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
        _skinsPanel.SetActive(false);
    }

    public void OpenSettingsButton()
    {
        if (SettingsButtons.CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
        _settingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        if (SettingsButtons.CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
        _settingsPanel.SetActive(false);
    }

    public void ExitGameButton()
    {
        if (SettingsButtons.CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
        Application.Quit();
    }

    public void GoTo2Board()
    {
        _onBoard_1.SetActive(false);
        _onBoard_2.SetActive(true);
    }

    public void GoTo3Board()
    {
        _onBoard_2.SetActive(false);
        _onBoard_3.SetActive(true);
    }

    public void GoToGame()
    {
        _onBoard_3.SetActive(false);
        PlayerPrefs.SetString("FirstEnter", "nope");
    }

}
