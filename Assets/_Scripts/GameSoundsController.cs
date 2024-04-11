using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundsController : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _levelCompleteSound;
    [SerializeField] private AudioClip _fallDownSound; 
    [SerializeField] private AudioClip _destroySound;
    [SerializeField] private AudioClip _winSound; 
    [SerializeField] private AudioClip _launchSound;
    [SerializeField] private AudioClip _tetivaSound;
    [SerializeField] private AudioClip _flySound;

    private AudioSource _audioSource;

    private void Awake()
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

    public void PlayLevelComleteSound()
    {
        _audioSource.PlayOneShot(_levelCompleteSound);
    }

    public void PlayFallSound()
    {
        _audioSource.PlayOneShot(_fallDownSound);
    }

    public void PlayDestroySound()
    {
        _audioSource.PlayOneShot(_destroySound);
    }

    public void PlayWinSound()
    {
        _audioSource.PlayOneShot(_winSound);
    }

    public void PlayLaunchSound()
    {
        _audioSource.PlayOneShot(_launchSound);
    }

    public void PlayTetivaSound()
    {
        _audioSource.PlayOneShot(_tetivaSound);
    }

    public void PlayFlySound()
    {
        _audioSource.PlayOneShot(_flySound);
    }

    public void StopAnySound()
    {
        _audioSource.Stop();
    }
}
