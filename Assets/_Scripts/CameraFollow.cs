using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _plane;

    private Vector3 _offset;
    private float _planePositionX;

    private void Start()
    {
        _planePositionX = _plane.transform.position.x;
        _offset = transform.position - _plane.position;
    }

    private void LateUpdate()
    {
        if (_plane.transform.position.x > _planePositionX)
        {
            Vector3 newPos = Vector3.Lerp(transform.position, _plane.position + _offset, 1f);
            transform.position = new Vector3(newPos.x, 0, newPos.z);

        }
    }
}
