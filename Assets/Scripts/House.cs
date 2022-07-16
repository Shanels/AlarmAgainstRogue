using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    [SerializeField] private UnityEvent _alarmOn;
    [SerializeField] private UnityEvent _alarmOff;
    [SerializeField] private GameObject _door;

    private bool _isDoorBroken = false;
    private bool _isSomebodyInHouse = false;

    private void Update()
    {             
        if (_door == null && _isDoorBroken == false)
        {            
            _isDoorBroken = true;
        }

        if (_isDoorBroken && _isSomebodyInHouse)
        {
            _alarmOn.Invoke();
        }
        else
        {
            _alarmOff.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Robber>(out Robber robber))
        {            
            _isSomebodyInHouse = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Robber>(out Robber robber))
        {           
            _isSomebodyInHouse = false;
        }
    }    
}
