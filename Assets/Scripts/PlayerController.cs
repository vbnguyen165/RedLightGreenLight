using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/* 
 * This class manages the behaviors of the Player.
 * It is responsible for enabling the walking movements of the player 
 * and dealing with win/lose conditions.
 */
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float gravityValue = -9.8f;
    private Vector3 playerGravity;
    private Vector2 moveVector;

    private CharacterController characterController;
    private Animator animator;

    [SerializeField] private AudioSource[] playerSounds;
    private AudioSource footStep;

    private float finishLine;
    public GameObject winTextObject;
    public GameObject loseTextObject;

    /* 
     * Start is called before the first frame update
     */
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        playerSounds = GetComponents<AudioSource>();
        footStep = playerSounds[1];

        finishLine = GameObject.Find("Finish Line").transform.position.z;
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!animator.GetBool("Dead"))
        {
            // Win
            if (gameObject.transform.position.z > finishLine)
            {
                winTextObject.SetActive(true);
            }
            Move();
        }
        // Lose
        else
        {
            loseTextObject.SetActive(true);
        }
    }
 
    void OnMove(InputValue movementValue)
    {
        moveVector = movementValue.Get<Vector2>();
        
        // Animation
        if (moveVector.x != 0 || moveVector.y != 0)
        {
            animator.SetBool("isWalking", true);
            if (!footStep.isPlaying)
            {
                footStep.Play();
            }
        }

        if (moveVector.x == 0 && moveVector.y == 0)
        {
            animator.SetBool("isWalking", false);
            if (footStep.isPlaying)
            {
                footStep.Stop();
            }
        }
    }

    /*
     * Moves player according to keyboard input
     */
    void Move()
    {
        Vector3 movementDirection = new Vector3(moveVector.x, 0, moveVector.y);
        
        // Rotate player to direction of movement
        if (movementDirection != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(movementDirection);

        if (characterController.isGrounded)
        {
            playerGravity.y = 0f;
        }
        else
        {
            playerGravity.y += gravityValue * Time.deltaTime;
            characterController.Move(playerGravity * Time.deltaTime);
        }

        characterController.Move(movementDirection * moveSpeed * Time.deltaTime);
    }
}
