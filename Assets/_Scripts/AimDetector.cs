using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDetector : MonoBehaviour
{
    [SerializeField] private GameObject _slider;
    private bool _isStopped;

    [SerializeField] private GameObject _plane_1;
    [SerializeField] private GameObject _plane_2;

    [SerializeField] private GameObject _splash;
    [SerializeField] GameSoundsController _gameSoundsController;

    private Rigidbody2D _rigidbody;
    private float _force;

    private void Start()
    {
        if (_plane_1.activeInHierarchy)
        {
            _rigidbody = _plane_1.GetComponent<Rigidbody2D>();
            _force = 9f;
        }
        else if (_plane_2.activeInHierarchy)
        {
            _rigidbody = _plane_2.GetComponent<Rigidbody2D>();
            _force = 9f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Target") && _isStopped == true)
        {
            _gameSoundsController.PlayJumpSound();
            GameObject splash = Instantiate(_splash);
            splash.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            splash.transform.SetParent(transform);
            Destroy(splash, 0.5f);
            _rigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
            _isStopped = false;
            gameObject.GetComponent<Animator>().speed = 1;
            return;
        }
    }

    public void ClickToFreeze()
    {
        if (_slider.activeInHierarchy)
        {
            if (GameController.CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Rigid);
            gameObject.GetComponent<Animator>().speed = 0;
            _isStopped = true;
        }

    }
}
