using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // @config param
    [SerializeField] Paddle paddle1; 
    //Paddle is a GameObject, but to have one of its type we must have a Script Paddle.cs
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 20f;
    [SerializeField] AudioClip[] ballSounds;
    bool hasStarted = false; // 

    // state we need
    Vector2 paddleToBallVector;


    // cached references
    //AudioSource audioSource = GetComponent<AudioSource>();


    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        // Fully depending on the default position of the ball manually set. 
        // We set it just top of paddle.
    }

    // Update is called once per frame
    void Update()
    {
        // without this we are locking the ball just after ball is launched, so nothing happens
        // we have make LockBallToPaddle() execute no more if the game has started, 
        // i.e - hasStarted = true
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // ball script, so rigidBody2D is also of the same
            hasStarted = true;
            // increasing the velocity, not the transform 
            // !!!!!!! IMPORTANT !!!!!!! transform is handled by LockBallToPaddle()
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioClip currentAudio = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
        if(hasStarted)
        {
            GetComponent<AudioSource>().PlayOneShot(currentAudio);
        }      
    }
}
