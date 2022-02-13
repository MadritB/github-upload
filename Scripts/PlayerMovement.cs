using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public float numOfHighJumps = 0;
    [SerializeField] private float jumpPowerNormal = 10f;
    [SerializeField] private float jumpPower = 10f;
    [SerializeField] private float maxspeed = 8f;
    [SerializeField] private float forwardForce = 10f;
    [SerializeField] private float multiplier = 0.5f;
    [SerializeField] private float extraGravity = 15f;
    [SerializeField] private float extraGravityUp = 10f;
    private bool spaceKeyWasPressed = false;
    private bool upKeyWasPressed = false;
    private bool isOnGround = true;
    public GameObject landSound;
    public GameObject jumpSound;

    public float cheat = 2f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            spaceKeyWasPressed = true;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            upKeyWasPressed = true;
        }
    }
    private void FixedUpdate() 
    {
        if(numOfHighJumps > 0)
        {
            jumpPower = 15f;
        }
        else if(numOfHighJumps == 0)
        {
            jumpPower = jumpPowerNormal;
        }
        if(isOnGround) // Checking if player is on ground
        {
            if(spaceKeyWasPressed) // Checking is space was pressed
            {
                rb.AddForce(0, jumpPowerNormal, 0, ForceMode.Impulse); // When player jumps, isOnground is false
                spaceKeyWasPressed = false;

                isOnGround = false;

                jumpSound.SetActive(true);
                landSound.SetActive(false);
            }

            if(upKeyWasPressed)
            {
                if(numOfHighJumps > 0)
                {
                    rb.AddForce(0, jumpPower, 0, ForceMode.Impulse);
                    upKeyWasPressed = false;
                    numOfHighJumps--;
                }
            }
        }
        if(rb.velocity.x < (maxspeed/2))
        {
            rb.AddForce(forwardForce, 0, 0, ForceMode.Acceleration);
        }
        else if(rb.velocity.x < (maxspeed/1.5))
        {
            rb.AddForce(forwardForce*multiplier, 0, 0, ForceMode.Acceleration);
        }
        else if(rb.velocity.x == maxspeed)
        {
            rb.AddForce(0,0,0);
        }

        if(rb.velocity.y < 0)
        {
            rb.AddForce(0, -extraGravity, 0);
        }
        if(rb.velocity.y > 0)
        {
            rb.AddForce(0 ,-extraGravityUp, 0);
        }

        if(Input.GetKey("c"))
        {
            rb.AddForce(0, cheat, 0, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collisionInfo) 
    {
        if(collisionInfo.collider.tag == "Ground") //When player hits ground, isOnGround becomes true
        {
            isOnGround = true;
            jumpSound.SetActive(false);
            landSound.SetActive(true);
        }
    }
}
