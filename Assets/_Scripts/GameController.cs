using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    [SerializeField] private GameObject _firstVariant;
    [SerializeField] private GameObject _SecondVariant;

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

    public void PauseButton()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void NextButton()
    {
        SceneManager.LoadScene("GameplayScene");
        //Level++;
    }
}
