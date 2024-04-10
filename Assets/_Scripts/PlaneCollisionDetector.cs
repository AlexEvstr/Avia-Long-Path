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

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _jump.SetActive(false);
        if (collision.gameObject.CompareTag("StartPlatform"))
        {
            StartCoroutine(SpawnExplosionEffect());
        }
        else if (collision.gameObject.CompareTag("Platform"))
        {
            StartCoroutine(SpawnSmokeEffect());
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            _winPanel.SetActive(true);
            _completedLeveText.text = $"LEVEL {GameData.Level} \n COMPLETED";
            GameData.Money = GameData.Level * 100;
            _moneyEarnedText.text = $"{GameData.Money} money earned";
            PlayerPrefs.SetInt("Money", GameData.Money);
            PlayerPrefs.SetInt("Level", GameData.Level + 1);
            Time.timeScale = 0; 
        }
    }

    private void ShowLosePanel()
    {
        _losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private IEnumerator SpawnSmokeEffect()
    {
        GameObject smoke = Instantiate(_smoke, transform);
        smoke.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.y);
        Destroy(smoke, 1.25f);
        yield return new WaitForSeconds(0.75f);
        StartCoroutine(SpawnExplosionEffect());
    }

    private IEnumerator SpawnExplosionEffect()
    {
        GameObject explosion = Instantiate(_explosion, transform);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(explosion, 0.5f);
        yield return new WaitForSeconds(0.5f);
        ShowLosePanel();
    }
}