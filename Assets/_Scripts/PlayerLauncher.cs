using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLauncher : MonoBehaviour
{
    [SerializeField] private GameObject _circles;
    [SerializeField] private GameObject _launch;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameSoundsController _gameSoundsController;

    private float _pitch;
    private float _force = 27.0f;

    private void Start()
    {
        Time.timeScale = 1;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        _pitch = transform.eulerAngles.z;
        Input.gyro.enabled = true;
        Input.gyro.updateInterval = 0.01f;
        _gameSoundsController.PlayTetivaSound();
    }
    

    void FixedUpdate()
    {
        _pitch += Input.gyro.rotationRateUnbiased.z * Mathf.Rad2Deg * Time.deltaTime;
        _circles.transform.eulerAngles = new Vector3(0, 0, _pitch);
    }

    public void LaunchPlane()
    {
        _gameSoundsController.PlayLaunchSound();
        if (GameController.CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Heavy);
        gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(_circles.transform.right * _force, ForceMode2D.Impulse);
        _circles.SetActive(false);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
        _launch.SetActive(false);
        _pauseButton.SetActive(true);
    }
}