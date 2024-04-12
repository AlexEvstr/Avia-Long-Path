using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Animations;
using UnityEngine.UIElements;

public class GameData : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private GameObject _pauseBtn;

    [SerializeField] private Animator _plane_1_Animator;
    [SerializeField] private Animator _plane_2_Animator;
    [SerializeField] private SpriteRenderer _plane_1_Sprite;
    [SerializeField] private SpriteRenderer _plane_2_Sprite;

    [SerializeField] private AnimatorController[] _planeAnimations;
    [SerializeField] private Sprite[] _planeSprites;

    [SerializeField] private GameObject _gemGameobject;

    [SerializeField] private GameObject[] _backgrounds;

    public static int Level;
    public static int BestLevel;
    public static int Money;

    private void OnEnable()
    {
        BestLevel = PlayerPrefs.GetInt("BestLevel", 1);
        int index = int.Parse(PlayerPrefs.GetString("Plane", "0"));
        _plane_1_Animator.runtimeAnimatorController = _planeAnimations[index];
        _plane_2_Animator.runtimeAnimatorController = _planeAnimations[index];
        _plane_1_Sprite.sprite = _planeSprites[index];
        _plane_2_Sprite.sprite = _planeSprites[index];

        for (int i = 0; i < _backgrounds.Length; i++)
        {
            if (int.Parse(PlayerPrefs.GetString("Background", "0")) == i)
                _backgrounds[i].SetActive(true);
            else
                _backgrounds[i].SetActive(false);
        }

        Level = PlayerPrefs.GetInt("Level", 1);
        Money = PlayerPrefs.GetInt("Money", 0);

        _levelText.text = $"LEVEL: {Level}";
        _moneyText.text = $"{Money}";


    }

    private void Update()
    {
        if (_pauseBtn.activeInHierarchy)
        {
            _levelText.text = null;
            _moneyText.text = null;
            _gemGameobject.SetActive(false);
        }
        if (Level > BestLevel)
        {
            BestLevel = Level;
            PlayerPrefs.SetInt("BestLevel", BestLevel);
        }
    }



}
