using UnityEngine;
public class EnemyMover : MonoBehaviour
{
    SpriteRenderer spriteRendered;

    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        spriteRendered = GetComponent<SpriteRenderer>();

        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }
    private void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;
            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }

        else if (target.position.x - transform.position.x < 0)
        {
            spriteRendered.flipX = false;
        }
        else if (target.position.x - transform.position.x > 0)
        {
            spriteRendered.flipX = true;
        }
    }
}
