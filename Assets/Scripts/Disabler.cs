using UnityEngine;

public class Disabler<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _objectsPool;
    [SerializeField] private float _radius;

    public T ObjectsPool => _objectsPool;
    public float Radius => _radius;
}
