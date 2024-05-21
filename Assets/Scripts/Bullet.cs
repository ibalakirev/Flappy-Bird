using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    protected float Speed => _speed;
}
