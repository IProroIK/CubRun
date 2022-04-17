using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levelParts;
    [SerializeField] private Transform _level;
    [SerializeField] private Transform _player;
    private Vector3 _nextPartPosition;
    private float _distanceToNewSpawn;
    private bool _canSpawn;



    private void Update()
    {
        CheckStepToGenerate();
        if(_canSpawn)
        {
            RandomPartGenerate();
            _canSpawn = false;
        }
    }

    private void CheckStepToGenerate()
    {
        if(_player.position.z > _distanceToNewSpawn)
        {
            _canSpawn = true;
            _distanceToNewSpawn += 30;
        }
    }

    private void RandomPartGenerate()
    {
        int randomIndex = Random.Range(0, _levelParts.Count);
        _nextPartPosition.z = GetComponent<Transform>().position.z + 60 + _distanceToNewSpawn;

        Instantiate(_levelParts[randomIndex], _nextPartPosition, Quaternion.identity, _level);
    }    


}
