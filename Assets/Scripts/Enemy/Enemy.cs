using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private WeaponEnemy _firePoint;

    public void Attack(SpawnerBulletsEnemy spawnerBulletsEnemy)
    {
        StartCoroutine(Shoot(spawnerBulletsEnemy));
    }

    private IEnumerator Shoot(SpawnerBulletsEnemy spawnerBulletsEnemy)
    {
        float delay = 3f;

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        while (enabled)
        {
            spawnerBulletsEnemy.Create(_firePoint.transform, transform.rotation);

            yield return timeWait;
        }
    }
}