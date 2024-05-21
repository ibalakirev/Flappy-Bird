using System;
using UnityEngine;

[RequireComponent(typeof(BirdCollisionHandler))]

public class Bird : MonoBehaviour
{
    private BirdCollisionHandler _birdCollisionHandler;

    public event Action GameOver;

    private void Awake()
    {
        _birdCollisionHandler = GetComponent<BirdCollisionHandler>();
    }

    private void OnEnable()
    {
        _birdCollisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _birdCollisionHandler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is BulletEnemy)
        {
            GameOver?.Invoke();
        }

        if (interactable is Enemy)
        {
            GameOver?.Invoke();
        }

        if (interactable is Fence)
        {
            GameOver?.Invoke();
        }
    }
}
