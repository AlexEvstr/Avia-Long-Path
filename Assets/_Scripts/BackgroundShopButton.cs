using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundShopButton : MonoBehaviour
{
    [SerializeField] private GameObject _clicked;
    [SerializeField] private int _totalCost;

    [SerializeField] private GameObject _cost;
    [SerializeField] private GameObject _choosen;

    private void Start()
    {
        string backgroundName = PlayerPrefs.GetString("Background", "");
        if (gameObject.name == backgroundName)
            _clicked.transform.SetParent(gameObject.transform);
    }

    public void ChooseThisBackground()
    {
        if (!_choosen.activeInHierarchy)
        {
            SkinsPanel.Money -= _totalCost;
            SaveStatus();
        }

        PlayerPrefs.SetString("Background", gameObject.name);
        _clicked.transform.SetParent(gameObject.transform);
        MakeBought();
    }

    private void SaveStatus()
    {
        if      (gameObject.name == "0") PlayerPrefs.SetString("background_0", "unlocked");
        else if (gameObject.name == "1") PlayerPrefs.SetString("background_1", "unlocked");
        else if (gameObject.name == "2") PlayerPrefs.SetString("background_2", "unlocked");
    }

    private void Update()
    {
        CheckBackground();
        CheckCost();
        CheckState();
    }

    private void CheckBackground()
    {
        if (gameObject.transform.childCount == 4)
            gameObject.GetComponent<Image>().color = Color.green;
        else
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
    }

    private void CheckCost()
    {
        if (_totalCost > SkinsPanel.Money && !_choosen.activeInHierarchy)
            gameObject.GetComponent<Button>().interactable = false;
        else
            gameObject.GetComponent<Button>().interactable = true;
    }

    private void CheckState()
    {
        if      (gameObject.name == "0") if (PlayerPrefs.GetString("background_0", "") != "") MakeBought();
        else if (gameObject.name == "1") if (PlayerPrefs.GetString("background_1", "") != "") MakeBought();
        else if (gameObject.name == "2") if (PlayerPrefs.GetString("background_2", "") != "") MakeBought();
    }

    private void MakeBought()
    {
        _cost.SetActive(false);
        _choosen.SetActive(true);
    }
}
