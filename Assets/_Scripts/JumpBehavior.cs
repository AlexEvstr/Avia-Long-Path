using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _plane_1;  
    [SerializeField] private GameObject _plane_2;
    private Rigidbody2D _rigidbody;
    private float _force = 500.0f;

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

    public void JumpForceButton()
    {
        if (_rigidbody.gravityScale > 0)
        {
            _rigidbody.AddForce(Vector2.up * _force);
        }
    }
}