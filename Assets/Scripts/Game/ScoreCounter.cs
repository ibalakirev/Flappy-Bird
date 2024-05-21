using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private DisablerEnemy _disablerEnemy;

    private int _score;

    public event Action<int> ScoreChanged;

    private void OnEnable()
    {
        _disablerEnemy.EnemyRemoved += Add;
    }

    private void OnDisable()
    {
        _disablerEnemy.EnemyRemoved += Add;
    }

    private void Add()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
}
