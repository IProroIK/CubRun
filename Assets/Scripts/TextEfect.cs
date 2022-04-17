using System.Collections;
using UnityEngine;

public class TextEfect : MonoBehaviour
{
    private int _lifeTime = 2;
    [SerializeField] private GameObject Canvas;
    void OnEnable()
    {
        StartCoroutine(AddEffectLifeTime());
    }

    private void OnDisable()
    {
        StopCoroutine(AddEffectLifeTime());
    }

    private IEnumerator AddEffectLifeTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        Canvas.SetActive(false);
    }

}
