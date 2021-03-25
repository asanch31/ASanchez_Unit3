﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    public float gravityModifer;
    public float jumpForce;
    private bool onGround = true;
    public bool gameOver = false;

    private Animator animPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifer;
        Physics.gravity = Physics.gravity * gravityModifer;

        animPlayer = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        bool spaceDown = Input.GetKeyDown(KeyCode.Space);
        if(spaceDown && onGround && !gameOver)
        {
            rbPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
            animPlayer.SetTrigger("Jump_trig");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
        else if (collision.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
            animPlayer.SetBool("Death_b", true);
            animPlayer.SetInteger("DeathType_int", 1);
        }
    }
}
