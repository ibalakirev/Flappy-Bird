using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BulletBird : Bullet
{
    private Rigidbody2D _rigidbody;
    private Coroutine _coroutine;
    private float _lifeTime = 3f;
    private bool _isLifeTimeCounted;
    private IInteractable _interactableDetected;

    public bool IsLifeTimeCounted => _isLifeTimeCounted;
    public IInteractable InteractableDetected => _interactableDetected;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _interactableDetected = null;

        _isLifeTimeCounted = false;

        Move();

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(CountLifeTime(_lifeTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IInteractable interactable))
        {
            _interactableDetected = interactable;
        }
    }

    private IEnumerator CountLifeTime(float lifeTime)
    {
        WaitForSeconds timeWait = new WaitForSeconds(lifeTime);

        yield return timeWait;

        _isLifeTimeCounted = true;
    }

    private void Move()
    {
        _rigidbody.velocity = transform.right * Speed;
    }
}
