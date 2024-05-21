using System;
using UnityEngine;

public class WeaponBird : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    public event Action ShotFired;

    private void Update()
    {
        if (_inputReader.GetInputShoot())
        {
            ShotFired?.Invoke();
        }
    }
}
