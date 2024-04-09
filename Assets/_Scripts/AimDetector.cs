using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDetector : MonoBehaviour
{
    [SerializeField] private GameObject _slider;
    private bool _isStopped;

    [SerializeField] private GameObject _plane_1;
    [SerializeField] private GameObject _plane_2;
    
    private Rigidbody2D _rigidbody;
    private float _force = 9f;

    private void Start()
    {
        if (_plane_1.activeInHierarchy)
        {
            _rigidbody = _plane_1.GetComponent<Rigidbody2D>();
        }
        else if (_plane_2.activeInHierarchy)
        {
            _rigidbody = _plane_2.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Target") && _isStopped == true)
        {
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
            gameObject.GetComponent<Animator>().speed = 0;
            _isStopped = true;
        }

    }
}
