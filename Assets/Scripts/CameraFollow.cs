using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * _speed * Time.deltaTime;
    }
}
