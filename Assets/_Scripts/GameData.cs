using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameData : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _moneyText;

    [SerializeField] private GameObject _pauseBtn;

    public static int Level;
    public static int BestLevel;
    public static int Money;

    private void OnEnable()
    {
        Level = PlayerPrefs.GetInt("Level", 1);
        Money = PlayerPrefs.GetInt("Money", 0);

        _levelText.text = $"LEVEL: {Level}";
        _moneyText.text = $"Money: {Money}";
    }

    private void Update()
    {
        if (_pauseBtn.activeInHierarchy)
        {
            _levelText.text = null;
            _moneyText.text = null;
        }
    }

}
