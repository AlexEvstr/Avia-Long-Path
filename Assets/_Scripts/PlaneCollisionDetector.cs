using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollisionDetector : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("StartPlatform"))
        {
            Debug.Log("start");
            _losePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("platfrom");
            _losePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            _winPanel.SetActive(true);
            Time.timeScale = 0; 
        }
    }
}
