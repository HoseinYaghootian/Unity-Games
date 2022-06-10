using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Rigidbody2D mario_rb;
    public bool is_dead = false;

    public CharacterController2D controller;
    public Animator animator;
    public GameObject enemy;
    
    public float speed = 20f;
    public bool isJumping = false;

    public float horizontalMove = 0f;

    

    void Start()
    {
        
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
       

        if(Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
        }

        if(transform.position.y < -1.3606)
        {
            is_dead = true;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;
    }

    public void Onlanding()
    {
        animator.SetBool("isJumping", false);
    }

    void OnCollisionEnter2D(Collision2D guest)
    {
        if (guest.gameObject.tag == "Enemy")
            is_dead = true;
    }


}
