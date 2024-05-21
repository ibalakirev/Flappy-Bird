using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BulletEnemy : Bullet, IInteractable
{
    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        Move();
    }

    private void Move()
    {
        _rigidbody.velocity = transform.right * Speed;
    }
}
