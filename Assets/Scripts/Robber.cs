using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Robber : MonoBehaviour
{
    [SerializeField] private UnityEvent _hit;
    [SerializeField] private UnityEvent _puckUp;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;

    private SpriteRenderer _renderer;

    private void Start()
    {
    _renderer = GetComponent<SpriteRenderer>();        
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = transform.right * _speed;

    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Door door))
        {
            _hit.Invoke();
            Destroy(door.gameObject);
        }

        if (collision.collider.TryGetComponent(out Gold gold))
        {
            _puckUp.Invoke();
            Destroy(gold.gameObject);
            _renderer.flipX = true;
            _speed = -_speed;
        }
    }
}
