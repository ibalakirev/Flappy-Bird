using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(InputReader))]

public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private InputReader _inputReader;
    private Vector3 _startPosition;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Rigidbody2D _rigidbody2D;
    private bool _isMove = false;

    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<InputReader>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        Reset();
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);

        Move();
    }

    private void Update()
    {
        if (_inputReader.GetInputMove())
        {
            _isMove = true;
        }
    }

    private void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody2D.velocity = Vector2.zero;
    }

    private void Move()
    {
        if (_isMove)
        {
            _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;

            _isMove = false;
        }
    }
}
