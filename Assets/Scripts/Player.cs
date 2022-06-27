using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Character playerInput;

    [SerializeField] private Transform cameraMain;

    private CharacterController controller;
    private Vector3 playerVelocity;
    //private bool groundedPlayer;

    [SerializeField] private float playerSpeed = 2.0f;

    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;


    void Awake()
    {
        playerInput = new Character();
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        //cameraMain = Camera.main.transform;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    void Update()
    {
        
        if (playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        Vector2 movementInput = playerInput.CharacterC.Move.ReadValue<Vector2>();

        Vector3 move = (cameraMain.forward * movementInput.y + cameraMain.right * movementInput.x);
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        

        playerVelocity.y = 0;
        controller.Move(playerVelocity * Time.deltaTime);

    }
}
