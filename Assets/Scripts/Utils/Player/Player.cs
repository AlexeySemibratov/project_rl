using System.Collections;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _speed;
    private Vector2 _moveDirection;
    private Vector2 _dashDirection;
    private bool _isOnDash;

    private Interactor _interactor;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _interactor = GetComponent<Interactor>();
    }

    
    void FixedUpdate()
    {
        if(_isOnDash)
        {
            UpdateOnDash();
        }
        else
        {
            NormalUpdate();
        }
    }

    private void UpdateOnDash()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _dashDirection * _speed * 5 * Time.fixedDeltaTime);
    }

    private void NormalUpdate()
    {
        if (_moveDirection != Vector2.zero)
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + _moveDirection.normalized * _speed * Time.fixedDeltaTime);
        }
    }


    public void OnMove(InputValue input)
    {
        _moveDirection = input.Get<Vector2>();
    }

    public void OnDash()
    {
        if (!_isOnDash && _moveDirection != Vector2.zero) StartCoroutine(DashSwitch());
    }

    public void OnInteract()
    {
        _interactor.Interact();
    }

    private IEnumerator DashSwitch()
    {
        _dashDirection = _moveDirection.normalized;
        _isOnDash = true;

        yield return new WaitForSeconds(0.2f);

        _isOnDash = false;
        _dashDirection = Vector2.zero;
    }
}
