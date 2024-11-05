using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField]private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    
    public bool IsRunning { get; private set; }
    public bool IsJumping { get; private set; }

    //[SerializeField] private PlayerAnim _anim;
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        var move = HandleInput();
        controller.Move(move * (Time.deltaTime * playerSpeed));

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            IsRunning = true;
        }
        else
        {
            IsRunning = false;
        }
        
        // Makes the player jump
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
            IsJumping = true;
        }
        else
        {
            IsJumping = false;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        
    }
    
    private Vector3 HandleInput()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0 ,Input.GetAxis("Vertical"));
    }
}
