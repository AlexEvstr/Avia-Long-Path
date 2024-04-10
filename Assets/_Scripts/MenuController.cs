using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _skinsPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _levelsPanel;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void LevelsButton()
    {
        _levelsPanel.SetActive(true);
    }

    public void CloseLevels()
    {
        _levelsPanel.SetActive(false);
    }

    public void SkinsButton()
    {
        _skinsPanel.SetActive(true);
    }

    public void CloseSkinsPanel()
    {
        _skinsPanel.SetActive(false);
    }

    public void SettingsButton()
    {
        _settingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        _settingsPanel.SetActive(false);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

}
