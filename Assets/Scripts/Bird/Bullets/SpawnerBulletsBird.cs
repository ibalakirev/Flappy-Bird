using UnityEngine;

public class SpawnerBulletsBird : Spawner<BulletsPoolBird>
{
    [SerializeField] private WeaponBird _weaponPlayer;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private int _quantityOjects;

    private void Start()
    {
        for (int i = 0; i < _quantityOjects; i++)
        {
            ObjectsPool.Initialize();
        }
    }

    private void OnEnable()
    {
        _weaponPlayer.ShotFired += Create;
    }

    private void OnDisable()
    {
        _weaponPlayer.ShotFired -= Create;
    }

    private void Create()
    {
        ObjectsPool.GetObject(_targetPoint.position, _targetPoint.rotation);
    }
}
