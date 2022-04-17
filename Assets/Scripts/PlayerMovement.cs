using UnityEngine;
using System;
public class PlayerMovement : MonoBehaviour
{
    public event Action OnGameStart;

    private const float _rightTrakeEdge = 2.3f;
    private const float _leftTrakeEdge = -2.3f;


    [SerializeField] private float _speed;
    [SerializeField] private float _sideMoveSpeed;

    private bool _isStarted;
    private Touch _touch;

    private void Update()
    {

        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)
            {
                OnGameStart.Invoke();
                _isStarted = true;
            }

                if (_touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(transform.position.x + _touch.deltaPosition.x * _sideMoveSpeed, transform.position.y, transform.position.z);
                    if (transform.position.x > _rightTrakeEdge)
                    {
                        transform.position = new Vector3(_rightTrakeEdge, transform.position.y, transform.position.z);
                    }
                    else if (transform.position.x < _leftTrakeEdge)
                    {
                        transform.position = new Vector3(_leftTrakeEdge, transform.position.y, transform.position.z);
                    }
                }
        }
        if (_isStarted) transform.position += Vector3.forward * _speed * Time.deltaTime;
    }


}
