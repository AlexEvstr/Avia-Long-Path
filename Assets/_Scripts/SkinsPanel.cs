using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkinsPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    public static int Money;

    private void Start()
    {
        Money = PlayerPrefs.GetInt("Money", 0);
        //Money = 99999;
    }

    private void Update()
    {
        _moneyText.text = $"{Money}";
    }
}
