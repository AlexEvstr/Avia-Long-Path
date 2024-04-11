using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundsController : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _jumpSound;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayClickSound()
    {
        _audioSource.PlayOneShot(_clickSound);
    }

    public void PlayJumpSound()
    {
        _audioSource.PlayOneShot(_jumpSound);
    }
}
