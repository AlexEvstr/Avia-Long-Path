using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _plane_1;
    [SerializeField] private Transform _plane_2;

    private Vector3 _offset1;
    private Vector3 _offset2;
    private float _plane1PositionX;
    private float _plane2PositionX;

    private void Start()
    {
        _plane1PositionX = _plane_1.transform.position.x;
        _offset1 = transform.position - _plane_1.position;

        _plane2PositionX = _plane_2.transform.position.x;
        _offset2 = transform.position - _plane_2.position;
    }

    private void LateUpdate()
    {
        if (_plane_1.gameObject.activeInHierarchy)
        {
            if (_plane_1.transform.position.x > _plane1PositionX && _plane_1.GetComponent<PlayerController>().enabled != true)
            {
                Vector3 newPos = Vector3.Lerp(transform.position, _plane_1.position + _offset1, 1f);
                transform.position = new Vector3(newPos.x, 0, newPos.z);
            }
        }
        else if (_plane_2.gameObject.activeInHierarchy)
        {
            if (_plane_2.transform.position.x > _plane2PositionX && _plane_2.GetComponent<Rigidbody2D>().gravityScale > 0)
            {
                Vector3 newPos = Vector3.Lerp(transform.position, _plane_2.position + _offset2, 1f);
                transform.position = new Vector3(newPos.x, 0, newPos.z);
            }
        }
    }
}
