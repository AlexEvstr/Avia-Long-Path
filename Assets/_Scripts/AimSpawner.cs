using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _slider;


    private void Start()
    {
        StartCoroutine(SpawnAim());
    }

    private IEnumerator SpawnAim()
    {
        yield return new WaitForSeconds(0.25f);
        _slider.SetActive(true);
    }
}
