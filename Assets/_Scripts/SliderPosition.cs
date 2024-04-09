using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPosition : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    private void FixedUpdate()
    {
        transform.position = new Vector3(_camera.transform.position.x + 5, 0, 0);
    }
}
