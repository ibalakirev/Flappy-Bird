using System.Collections;
using UnityEngine;

public class SpawnerEnemies : Spawner<EnemiesPool>
{
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private SpawnerBulletsEnemy _spawnerBulletsEnemy;

    private void Start()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        float delay = 2f;

        WaitForSeconds timeWait = new WaitForSeconds(delay);

        while (enabled)
        {
            yield return timeWait;

            Create();
        }
    }

    private void Create()
    {
        float rotatePositionX = 0f;
        float rotatePositionY = 180f;
        float rotatePositionZ = 0f;
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);

        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        ObjectsPool.Initialize();

        Enemy newEnemy = ObjectsPool.GetObject(spawnPoint, Quaternion.Euler(rotatePositionX, rotatePositionY, rotatePositionZ));

        newEnemy.Attack(_spawnerBulletsEnemy);
    }
}
