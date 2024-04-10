using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    [SerializeField] private GameObject _firstVariant;
    [SerializeField] private GameObject _SecondVariant;

    public static bool CanVibro;

    private void OnEnable()
    {
        int variant = PlayerPrefs.GetInt("variant", 1);
        if (variant == 1)
        {
            _SecondVariant.SetActive(false);
            _firstVariant.SetActive(true);
        }
        else
        {
            _firstVariant.SetActive(false);
            _SecondVariant.SetActive(true);
        }
    }

    private void Start()
    {
        Vibration.Init();
        int vibro = PlayerPrefs.GetInt("vibro", 1);
        if (vibro == 1) CanVibro = true;
        else CanVibro = false;
    }

    public void PauseButton()
    {
        if (CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        if (CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartButton()
    {
        if (CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
        SceneManager.LoadScene("GameplayScene");
    }

    public void MenuButton()
    {
        if (CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
        SceneManager.LoadScene("MenuScene");
    }

    public void NextButton()
    {
        if (CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
        SceneManager.LoadScene("GameplayScene");
    }
}