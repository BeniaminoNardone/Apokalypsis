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
    // Determina i vettori globali per destra e in avanti
    Vector3 globalRight = Vector3.right;
    Vector3 globalForward = Vector3.forward;
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

        // Porta i valori normalizzati a 1, -1 o lascia 0 se già 0
        int horizontalI = (horizontalInput > 0) ? 1 : (horizontalInput < 0) ? -1 : 0;
       int  verticalI = (verticalInput > 0) ? 1 : (verticalInput < 0) ? -1 : 0;

        _rigidbody.velocity = new Vector3(horizontalI * _moveSpeed, _rigidbody.velocity.y, verticalI * _moveSpeed);

            // Aggiorna l'animator con i valori normalizzati
            _animator.SetFloat("Horizontal", horizontalInput);
            _animator.SetFloat("Vertical", verticalInput);
            _animator.SetFloat("Speed", new Vector2(horizontalInput, verticalInput).magnitude);
        
        


        if (horizontalInput != 0 && verticalInput != 0)
        {


            // Calcola la nuova posizione dell'attack point rispetto alla rotazione del giocatore
            Vector3 attackPointLocalPosition = new Vector3(horizontalInput * 5, 0f, verticalInput * 5);
            Vector3 attackPointWorldPosition = transform.TransformPoint(attackPointLocalPosition);

            // Aggiorna la posizione dell'attack point
            attackPoint.position = attackPointWorldPosition;

        }


        if (horizontalInput != 0 && verticalInput != 0)
        {
            // Calcola la prossima idle
            _animator.SetFloat("IdleHorizontal", horizontalInput);
            _animator.SetFloat("IdleVertical", verticalInput);
        }


    }

}
