using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _slider;
    [SerializeField] private GameObject _plane_1;
    [SerializeField] private GameObject _plane_2;

    [SerializeField] GameSoundsController _gameSoundsController;

    private float _time;


    private void Start()
    {
        _gameSoundsController.PlayFlySound();
        if (_plane_1.activeInHierarchy)
        {
            _time = 1.0f;
        }
        else if (_plane_2.activeInHierarchy)
        {
            _time = 0.75f;
        }
        StartCoroutine(SpawnAim());
    }

    private IEnumerator SpawnAim()
    {
        yield return new WaitForSeconds(_time);
        _slider.SetActive(true);
    }

}