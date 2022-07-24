using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    [SerializeField] private UnityEvent _doorWasBroken;
    [SerializeField] private GameObject _door;
    
    public static bool IsRobberInHouse { get; private set; } = false;

    private void Update()
    {
        if (_door == null)
        {
            _doorWasBroken.Invoke();
        }
    }
}