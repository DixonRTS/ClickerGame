using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float jumpForce = 9f;
    public float gravity = 9.81f * 2f;
    
    
    private void Awake()
    {
         character = GetComponent<CharacterController>();
         
         
         
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime;
        character.Move(direction * Time.deltaTime);
        
        
    }

    public void GetButton()
    {
        if (character.isGrounded)
        {
            direction = Vector3.down;

            direction = Vector3.up * jumpForce;
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("Enemy"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
