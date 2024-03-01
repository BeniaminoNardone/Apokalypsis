using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;

    public Transform attackPoint;

    private void FixedUpdate()
    {
        float horizontalInput = (_joystick.Horizontal != 0) ? _joystick.Horizontal : Input.GetAxis("Horizontal");
        float verticalInput = (_joystick.Vertical != 0) ? _joystick.Vertical : Input.GetAxis("Vertical");

        horizontalInput = Mathf.Clamp(horizontalInput, -1f, 1f);
        verticalInput = Mathf.Clamp(verticalInput, -1f, 1f);

        if (horizontalInput <= 0.3f && horizontalInput >= -0.3f)
        {
            horizontalInput = 0;
        }
        if (verticalInput <= 0.251f && verticalInput >= -0.251f)
        {
            verticalInput = 0;
        }

        int horizontalI = (horizontalInput > 0) ? 1 : (horizontalInput < 0) ? -1 : 0;
        int verticalI = (verticalInput > 0) ? 1 : (verticalInput < 0) ? -1 : 0;
        _rigidbody.velocity = new Vector3(horizontalI * _moveSpeed, _rigidbody.velocity.y, verticalI * _moveSpeed);

        _animator.SetFloat("Horizontal", horizontalInput);
        _animator.SetFloat("Vertical", verticalInput);
        _animator.SetFloat("Speed", new Vector2(horizontalInput, verticalInput).magnitude);

        if (horizontalInput != 0 || verticalInput != 0)
        {
          

            Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
            Vector3 attackPointLocalPosition = moveDirection.normalized * 5f;
            Vector3 attackPointWorldPosition = transform.TransformPoint(attackPointLocalPosition);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
            {
                attackPointWorldPosition.y = hit.point.y;
            }
            Vector3 offsety = new Vector3(0f,3f,0f);
            attackPoint.position = attackPointWorldPosition+offsety;
        }

        if (horizontalInput != 0 || verticalInput != 0)
        {
            _animator.SetFloat("IdleHorizontal", horizontalInput);
            _animator.SetFloat("IdleVertical", verticalInput);
        }
    }
}
