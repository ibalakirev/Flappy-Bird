using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    private bool _isCollisionHandler;

    public bool IsCollisionHandler => _isCollisionHandler;

    private void OnEnable()
    {
        _isCollisionHandler = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out BulletBird bulletBird))
        {
            _isCollisionHandler = true;
        }
    }
}
