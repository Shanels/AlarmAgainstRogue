using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    [SerializeField] private UnityEvent _robberEnter;
    [SerializeField] private UnityEvent _robberLeft;
    [SerializeField] private GameObject _door;

    public static bool IsDoorBroken { get; private set; } = false;
    public static bool IsRobberInHouse { get; private set; } = false;

    private void Update()
    {
        if (_door == null && IsDoorBroken == false)
        {
            IsDoorBroken = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Robber>(out Robber robber))
        {
            IsRobberInHouse = true;
            _robberEnter.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Robber>(out Robber robber))
        {
            IsRobberInHouse = false;
            _robberLeft.Invoke();
        }
    }
}
