using UnityEngine;

public class CubeStaker : MonoBehaviour
{

    [SerializeField] private Transform _cubeHolder;
    [SerializeField] private Transform _stickman;
    [SerializeField] private Transform _poolContainer;
    private Vector3 _newPosition;
    private Vector3 _newStickmanPosition;

    private int _poolCount = 8;
    private bool _autoExpand = true;
    [SerializeField]private TextEfect _textEfect;
    private PoolMono<TextEfect> _pool;


    private void Start()
    {
        this._pool = new PoolMono<TextEfect>(this._textEfect, this._poolCount, this._poolContainer);
        this._pool.autoExapand = this._autoExpand;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out YellowBlock yellowBlock))
        {
            other.transform.SetParent(_cubeHolder);
            _newPosition.y = this.transform.childCount -1f;
            _newPosition.x = 0;
            _newPosition.z = 0;
            _newStickmanPosition.x = 0;
            _newStickmanPosition.z = 0;
            var cubeText = this._pool.GetFreeElement();
            cubeText.transform.position = new Vector3(this.transform.position.x, _newPosition.y + 2f, this.transform.position.z);
            _newStickmanPosition.y = _newPosition.y + 2f;
            _stickman.localPosition = new Vector3(0, other.transform.position.y + 3f, 0);
            other.transform.localPosition = _newPosition;
        }
    }
}
