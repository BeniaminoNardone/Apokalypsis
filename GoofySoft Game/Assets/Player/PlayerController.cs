using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float   _moveSpeed;

    Vector2 movement;
     
    public Transform attackPoint;

    private void Start()
    {
        
    }

    private void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
       // _animator.SetFloat("Horizontal", movement.x); _animator.SetFloat("Vertical", movement.y); _animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        float horizontalInput;
        float verticalInput;
        if (_joystick.Horizontal == 0 && _joystick.Vertical== 0)
        {

             horizontalInput = Input.GetAxis("Horizontal");
             verticalInput = Input.GetAxis("Vertical");

        }
        else
        {

             horizontalInput = _joystick.Horizontal;
             verticalInput = _joystick.Vertical;
        }






        // Normalizza i valori per assicurarsi che siano compresi tra -1 e 1
        horizontalInput = Mathf.Clamp(horizontalInput, -1f, 1f);
        verticalInput = Mathf.Clamp(verticalInput, -1f, 1f);

       
            _rigidbody.velocity = new Vector3(horizontalInput * _moveSpeed, _rigidbody.velocity.y, verticalInput * _moveSpeed);

            // Aggiorna l'animator con i valori normalizzati
            _animator.SetFloat("Horizontal", horizontalInput);
            _animator.SetFloat("Vertical", verticalInput);
            _animator.SetFloat("Speed", new Vector2(horizontalInput, verticalInput).magnitude);
        
        


        if (horizontalInput != 0 && verticalInput != 0)
        {
            // Calcola la posizione dell'attackPoint
            Vector3 attackPointPosition = transform.position + transform.right * horizontalInput + transform.forward * verticalInput;

            attackPoint.position = attackPointPosition;
 
        }


        if (horizontalInput != 0 && verticalInput != 0)
        {
            // Calcola la prossima idle
            _animator.SetFloat("IdleHorizontal", horizontalInput);
            _animator.SetFloat("IdleVertical", verticalInput);
        }


    }

}
