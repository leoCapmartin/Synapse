using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    
    public float speed = 12f;
    public float gravity = -9.81f * 1.5f;
    public float heightJump = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.8f;
    public LayerMask groundMask;

    private Vector3 _playerVelocity;
    private bool _isGrouded;

    void Update()
    {
        _isGrouded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (_isGrouded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        if (_playerVelocity.y < -5f)
        {
            _playerVelocity.y = 0f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * (speed * Time.deltaTime));
        
        if (Input.GetKeyDown(KeyCode.Space) && _isGrouded)
        {
            _playerVelocity.y += Mathf.Sqrt(heightJump * -2f * gravity);
        }
        
        _playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(_playerVelocity * Time.deltaTime);
    }
}
