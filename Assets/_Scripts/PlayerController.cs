using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _startPosision;
    private Vector3 _endPosition;
    public Vector3 _initPosition;
    private Rigidbody2D _rigidbody;
    private Vector3 _forceAtPlayer;
    public float Force;

    public GameObject trajectoryCircle;
    private GameObject[] trajectoryCircles;
    public int numberOfCircles;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameSoundsController _gameSoundsController;


    private void Start()
    {
        Time.timeScale = 1;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        gameObject.AddComponent<PolygonCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        trajectoryCircles = new GameObject[numberOfCircles];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _gameSoundsController.PlayTetivaSound();
            _startPosision = gameObject.transform.position;
            for (int i = 0; i < numberOfCircles; i++)
            {
                trajectoryCircles[i] = Instantiate(trajectoryCircle, gameObject.transform);
            }

        }
        if (Input.GetMouseButton(0))
        {
            _endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            gameObject.transform.position = _endPosition;
            _forceAtPlayer = _endPosition - _startPosision;
            for (int i = 0; i < numberOfCircles; i++)
            {
                if (GameController.CanVibro) Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
                trajectoryCircles[i].transform.position = CalculatePosition(i * 0.1f);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _gameSoundsController.PlayLaunchSound();
            _rigidbody.gravityScale = 1;
            _rigidbody.velocity = new Vector2(-_forceAtPlayer.x * Force, -_forceAtPlayer.y * Force);
            for (int i = 0; i < numberOfCircles; i++)
            {
                Destroy(trajectoryCircles[i]);
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                gameObject.GetComponent<PlayerController>().enabled = false;
                _pauseButton.SetActive(true);
            }
        }
    }

    private Vector2 CalculatePosition(float elapsedTime)
    {
        return new Vector2(_endPosition.x, _endPosition.y) +
               new Vector2(-_forceAtPlayer.x * Force, -_forceAtPlayer.y * Force) * elapsedTime +
                0.5f * Physics2D.gravity * elapsedTime * elapsedTime;
    }
}