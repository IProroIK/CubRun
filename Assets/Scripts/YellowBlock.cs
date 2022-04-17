using System.Collections;
using UnityEngine;
using DG.Tweening;
public class YellowBlock : MonoBehaviour
{

    private const float _shakeDuration = 0.5f;
    private const float _shakeStrength = 2f;
    private const int _shakeVibrato = 2;


    [SerializeField] private Transform _carbage;
    private Rigidbody _rigidbody;
    private Camera _mainCamera;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            YellowBlockDestroy();
            _rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;
            _mainCamera.DOShakeRotation(_shakeDuration, _shakeStrength, _shakeVibrato);
            StartCoroutine(WaitToFreezZAsix());
        }

    }

    private IEnumerator WaitToFreezZAsix()
    {
        yield return new WaitForSeconds(0.5f);
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;

    }

    private void YellowBlockDestroy()
    {
        this.transform.SetParent(_carbage);
        Destroy(this.gameObject, 0.5f);
    }
}
