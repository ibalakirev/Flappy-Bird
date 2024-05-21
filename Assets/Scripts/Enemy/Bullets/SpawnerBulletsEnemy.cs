using UnityEngine;

public class SpawnerBulletsEnemy : Spawner<BulletsPoolEnemy>
{
    public void Create(Transform pointPositon, Quaternion rotate)
    {
        ObjectsPool.GetObject(pointPositon.position, rotate);
    }
}
