using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneCollisionDetector : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;

    [SerializeField] private TMP_Text _completedLeveText;
    [SerializeField] private TMP_Text _moneyEarnedText;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("StartPlatform"))
        {
            Debug.Log("start");
            _losePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("platfrom");
            _losePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            _winPanel.SetActive(true);
            _completedLeveText.text = $"LEVEL {GameData.Level} \n COMPLETED";
            GameData.Money = GameData.Level * 100;
            _moneyEarnedText.text = $"{GameData.Money} money earned";
            PlayerPrefs.SetInt("Money", GameData.Money);
            PlayerPrefs.SetInt("Level", GameData.Level + 1);
            Time.timeScale = 0; 
        }
    }
}
