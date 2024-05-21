using System;
using System.Collections;
using UnityEngine;

public class DisablerEnemy : Disabler<EnemiesPool>
{
    public event Action EnemyRemoved;

    private void Start()
    {
        StartCoroutine(KeepTrackColliders());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }

    private IEnumerator KeepTrackColliders()
    {
        float delay = 0.02f;

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        while (enabled)
        {
            Collider2D[] overlappedColliders = Physics2D.OverlapCircleAll(transform.position, Radius);

            for (int i = 0; i < overlappedColliders.Length; i++)
            {
                if (overlappedColliders[i].TryGetComponent(out Enemy enemy))
                {
                    TryRemoveEnemy(enemy);
                }
            }

            yield return timeWait;
        }
    }

    private void TryRemoveEnemy(Enemy enemy)
    {
        if (enemy.TryGetComponent(out EnemyCollisionHandler enemyCollisionHandler))
        {
            if (enemyCollisionHandler.IsCollisionHandler)
            {
                ObjectsPool.ReturnObject(enemy);

                EnemyRemoved?.Invoke();
            }
        }
    }
}
