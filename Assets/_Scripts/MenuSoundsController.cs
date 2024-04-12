using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundsController : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _skinBuySound;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayClickSound()
    {
        _audioSource.PlayOneShot(_clickSound);
    }

    public void PlaySkinBuySound()
    {
        _audioSource.PlayOneShot(_skinBuySound);
    }
}
