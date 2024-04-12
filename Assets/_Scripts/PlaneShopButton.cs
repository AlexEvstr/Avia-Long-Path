using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneShopButton : MonoBehaviour
{
    [SerializeField] private GameObject _clicked;
    [SerializeField] private int _totalCost;
    [SerializeField] private GameObject _cost;
    [SerializeField] private GameObject _choosen;
    [SerializeField] private MenuSoundsController _menuSoundsController;

    private void Start()
    {
        string planeName = PlayerPrefs.GetString("Plane", "");
        if (gameObject.name == planeName)
            _clicked.transform.SetParent(gameObject.transform);
    }

    public void ChooseThisPlane()
    {
        if (!_choosen.activeInHierarchy)
        {
            SkinsPanel.Money -= _totalCost;
            SaveStatus();
            _menuSoundsController.PlaySkinBuySound();
        }
        else
        {
            _menuSoundsController.PlayClickSound();
        }

        PlayerPrefs.SetString("Plane", gameObject.name);
        _clicked.transform.SetParent(gameObject.transform);
        MakeBought();
    }

    private void SaveStatus()
    {
        if      (gameObject.name == "0") PlayerPrefs.SetString("plane_0", "unlocked");
        else if (gameObject.name == "1") PlayerPrefs.SetString("plane_1", "unlocked");
        else if (gameObject.name == "2") PlayerPrefs.SetString("plane_2", "unlocked");
        else if (gameObject.name == "3") PlayerPrefs.SetString("plane_3", "unlocked");
    }

    private void Update()
    {
        CheckPlane();
        CheckCost();
        CheckState();
    }

    private void CheckPlane()
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
        if      (gameObject.name == "0")
        {
            if (PlayerPrefs.GetString("plane_0", "") != "") MakeBought();
        }

            
        else if (gameObject.name == "1")
        {
            if (PlayerPrefs.GetString("plane_1", "") != "") MakeBought();
        }
                
        else if (gameObject.name == "2")
        {
            if (PlayerPrefs.GetString("plane_2", "") != "") MakeBought();
        }
                    
        else if (gameObject.name == "3")
        {
            if (PlayerPrefs.GetString("plane_3", "") != "") MakeBought();
        }
                        
    }

    private void MakeBought()
    {
        _cost.SetActive(false);
        _choosen.SetActive(true);
    }
}