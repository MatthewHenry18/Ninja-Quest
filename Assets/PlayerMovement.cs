using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;    //store movement speed
    private Rigidbody2D rb;     //store rigid body compoonent
    private Vector2 moveInput;  //store our movements
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //to access rigid body we need to get component of what this script is attached to
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //set our rigid body velocity from input
        rb.velocity = moveInput * moveSpeed;
    }

    //Setting our moveInput variable using input actions
    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);

        //signalled when we release a button
        if(context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);

        }

        moveInput = context.ReadValue<Vector2>();
        //passing input values to animator 
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }
}
