using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _movement;
    private Rigidbody2D _rb2d;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _movement = Input.GetAxis("Horizontal");
        _animator.SetFloat("Speed", Mathf.Abs(_movement));
    }

    private void FixedUpdate()
    {
        _rb2d.MovePosition(_rb2d.position + new Vector2(_movement, 0) * _speed * Time.fixedDeltaTime);
        Flip();
    }

    private void Flip()
    {
        if (_movement < 0)
        {
            _spriteRenderer.flipX = true;
        }

        if (_movement > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}