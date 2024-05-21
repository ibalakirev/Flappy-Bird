using UnityEngine;

public class EnemiesRemover : MonoBehaviour
{
    [SerializeField] private EnemiesPool _enemiesPool;
    [SerializeField] private BulletsPoolEnemy _bulletsPoolEnemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _enemiesPool.ReturnObject(enemy);
        }

        if (other.TryGetComponent(out BulletEnemy bulletEnemy))
        {
            _bulletsPoolEnemy.ReturnObject(bulletEnemy);
        }
    }
}
