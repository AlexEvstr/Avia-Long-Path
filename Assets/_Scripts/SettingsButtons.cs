using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButtons : MonoBehaviour
{
    [SerializeField] private GameObject _sound_on;
    [SerializeField] private GameObject _sound_off;
    [SerializeField] private GameObject _vibro_on;
    [SerializeField] private GameObject _vibro_off;
    [SerializeField] private Image _firstButton;
    [SerializeField] private Image _SecondButton;

    public static bool CanVibro;

    private void Start()
    {
        int canVibro = PlayerPrefs.GetInt("vibro", 1);
        if (canVibro == 1) VibroOn();
        else VibroOff();
        //CanVibro = false;
        float sound = PlayerPrefs.GetFloat("sounds", 1);
        if (sound == 1) SoundOn();
        else SoundOff();

        int variant = PlayerPrefs.GetInt("variant", 1);
        if (variant == 1) FirstVariantOfControll();
        else SecondVariantOfCOntrol();



    }

    public void SoundOff()
    {
        if (CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
        _sound_on.SetActive(false);
        _sound_off.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetFloat("sounds", AudioListener.volume);
    }

    public void SoundOn()
    {
        if (CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
        _sound_off.SetActive(false);
        _sound_on.SetActive(true);
        AudioListener.volume = 1;
        PlayerPrefs.SetFloat("sounds", AudioListener.volume);
    }

    public void VibroOff()
    {
        _vibro_on.SetActive(false);
        _vibro_off.SetActive(true);
        CanVibro = false;
        PlayerPrefs.SetInt("vibro", 0);
    }

    public void VibroOn()
    {
        _vibro_off.SetActive(false);
        _vibro_on.SetActive(true);
        CanVibro = true;
        PlayerPrefs.SetInt("vibro", 1);
        if (CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
    }


    public void FirstVariantOfControll()
    {
        if (CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Medium);
        PlayerPrefs.SetInt("variant", 1);
        _firstButton.color = Color.green;
        _SecondButton.color = new Color(1, 1, 1, 1);
    }

    public void SecondVariantOfCOntrol()
    {
        if (CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Medium);
        PlayerPrefs.SetInt("variant", 2);
        _SecondButton.color = Color.green;
        _firstButton.color = new Color(1, 1, 1, 1);
    }
}