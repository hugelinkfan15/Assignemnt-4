/*
* Kayden Miller
* Assignment 4
* Script to move character when user gives an input
*/

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    public ParticleSystem explosion;
    public ParticleSystem dirtTrail;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;

    private Rigidbody playerRB;

    private Animator pA;

    // Start is called before the first frame update
    void Start()
    {
        pA = GetComponent<Animator>();
        pA.SetFloat("Speed_f", 1.0f);

        playerRB = GetComponent<Rigidbody>();

        playerAudio = GetComponent<AudioSource>();

        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& isOnGround && !gameOver)
        {
            dirtTrail.Stop();
            pA.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            playerRB.AddForce(Vector3.up *jumpForce,jumpForceMode);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            dirtTrail.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            gameOver = true;
            dirtTrail.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            explosion.Play();
            pA.SetBool("Death_b", true);
            pA.SetInteger("DeathType_int", 1);
        }
    }
}
