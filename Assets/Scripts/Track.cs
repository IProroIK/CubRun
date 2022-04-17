using System.Collections;
using UnityEngine;

public class Track : MonoBehaviour
{
    private float _lifeTime = 25;

    private void Start()    
    {
        StartCoroutine(AddEffectLifeTime());
    }

    private IEnumerator AddEffectLifeTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(this.gameObject);
    }

}
