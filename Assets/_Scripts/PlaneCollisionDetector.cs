using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneCollisionDetector : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;

    [SerializeField] private TMP_Text _completedLeveText;
    [SerializeField] private TMP_Text _moneyEarnedText;

    [SerializeField] private GameObject _smoke;
    [SerializeField] private GameObject _explosion;

    [SerializeField] private GameObject _jump;
    [SerializeField] private GameObject _finishEffect;

    [SerializeField] private GameSoundsController _gameSoundsController;

    [SerializeField] private GameObject _pauseBTN;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _pauseBTN.SetActive(false);
        _gameSoundsController.StopAnySound();
        _jump.SetActive(false);
        if (collision.gameObject.CompareTag("StartPlatform"))
        {
            _gameSoundsController.PlayDestroySound();
            if (GameController.CanVibro) Vibration.Vibrate();
            StartCoroutine(SpawnExplosionEffect());
        }
        else if (collision.gameObject.CompareTag("Platform"))
        {
            _gameSoundsController.PlayFallSound();

            if (GameController.CanVibro) Vibration.Vibrate();
            StartCoroutine(SpawnSmokeEffect());
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            StartCoroutine(FinishBEhavior());

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;

            _completedLeveText.text = $"LEVEL {GameData.Level} \n COMPLETED";
            int earnedMoney = GameData.Level * 100;
            _moneyEarnedText.text = $"{earnedMoney} earned";
            GameData.Money += earnedMoney;
            PlayerPrefs.SetInt("Money", GameData.Money);
            GameData.Level++;
            PlayerPrefs.SetInt("Level", GameData.Level);
            
        }
    }

    private IEnumerator FinishBEhavior()
    {
        _gameSoundsController.PlayWinSound();
        if (GameController.CanVibro) Vibration.VibrateIOS(NotificationFeedbackStyle.Success);
        GameObject finishEffect = Instantiate(_finishEffect);
        finishEffect.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(2);
        _gameSoundsController.PlayLevelComleteSound();
        Destroy(finishEffect);
        _winPanel.SetActive(true);
    }

    private void ShowLosePanel()
    {
        _losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private IEnumerator SpawnSmokeEffect()
    {
        if (GameController.CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Soft);
        GameObject smoke = Instantiate(_smoke, transform);
        smoke.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.y);
        Destroy(smoke, 1.25f);
        yield return new WaitForSeconds(0.75f);
        _gameSoundsController.PlayDestroySound();
        StartCoroutine(SpawnExplosionEffect());
    }

    private IEnumerator SpawnExplosionEffect()
    {
        if (GameController.CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Heavy);
        GameObject explosion = Instantiate(_explosion, transform);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(explosion, 0.5f);
        yield return new WaitForSeconds(0.5f);
        ShowLosePanel();
    }
}