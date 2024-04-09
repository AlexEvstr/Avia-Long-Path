using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLauncher : MonoBehaviour
{
    [SerializeField] private GameObject _circles;
    private float _pitch;
    private float _force = 10.0f;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        _pitch = transform.eulerAngles.z;
        Input.gyro.enabled = true;
        Input.gyro.updateInterval = 0.01f;
    }
    

    void FixedUpdate()
    {
        //float accelz = Input.gyro.attitude.z;
        _pitch += Input.gyro.rotationRateUnbiased.z * Mathf.Rad2Deg * Time.deltaTime;

        //float angle = Mathf.Asin(pitch) * Mathf.Rad2Deg;

        _circles.transform.eulerAngles = new Vector3(0, 0, _pitch);
    }

    public void LaunchPlane()
    {
        gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(_circles.transform.right * _force, ForceMode2D.Impulse);
        _circles.SetActive(false);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
