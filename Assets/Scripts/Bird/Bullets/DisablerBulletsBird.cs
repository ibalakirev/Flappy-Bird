using System.Collections;
using UnityEngine;

public class DisablerBulletsBird : Disabler<BulletsPoolBird>
{
    [SerializeField] private Bird _bird;

    private void Start()
    {
        StartCoroutine(KeepTrackColliders());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_bird.transform.position, Radius);
    }

    private IEnumerator KeepTrackColliders()
    {
        float delay = 0.02f;

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        while (enabled)
        {
            Collider2D[] overlappedColliders = Physics2D.OverlapCircleAll(_bird.transform.position, Radius);

            for (int i = 0; i < overlappedColliders.Length; i++)
            {
                if (overlappedColliders[i].TryGetComponent(out BulletBird bulletBird))
                {
                    if (TryIsCollision(bulletBird) || TryIsLifeTime(bulletBird))
                    {
                        RemoveBullet(bulletBird);
                    }
                }
            }

            yield return timeWait;
        }
    }

    private bool TryIsCollision(BulletBird bulletBird)
    {
        return bulletBird.InteractableDetected is Enemy || bulletBird.InteractableDetected is Fence;
    }

    private bool TryIsLifeTime(BulletBird bulletBird)
    {
        return bulletBird.IsLifeTimeCounted;
    }

    private void RemoveBullet(BulletBird bulletBird)
    {
        ObjectsPool.ReturnObject(bulletBird);
    }
}
