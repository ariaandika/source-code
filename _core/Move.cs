using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    /// <summary>
    /// MAIN MOVEMENT
    /// </summary>
    
    [Header("Base Stats")]
    [Serializefield] float speed = 6;
    [Serializefield] float jumpHeight = 8;
    [Serializefield] float gravity = -25;

    [Header("Feature Toogle")]
    bool Glide;
    bool Run;
    bool Crouch;

    // Movement var
    float runModifier;

    // Reference
    CharacterController c;

    // Air var
    Vector3 velocity;
    bool isGrounded;

    // Glide
    bool isGliding = false;
    float glideHeightRay = 6;	// distance from ground to be able to glide
    float glideGravMod = 25;
    float glideMsMod = 2;

    //Crouch

    private void Start()
    {
        c = GetComponent<CharacterController>();
    }

    void Update()
    {

        isGrounded = c.isGrounded;

        // Move & Sprint
        if (isGrounded)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
            runModifier = Input.GetAxis("Run") + 1;
        }

        c.height = -Input.GetAxis("Crouch") + 2;

        Vector3 move = transform.right * x + transform.forward * z;
        c.Move(move * speed * Time.deltaTime * runModifier * (isGliding ? glideMsMod : 1));


        // Jump & Gravity & Glide
        if (isGrounded && velocity.y <= 0) { velocity.y = -2; isGliding = false; }
        if (velocity.y > 0)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if (velocity.y <= 0)
        {
            velocity.y += gravity * Time.deltaTime * 2 / (isGliding ? glideGravMod : 1);
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                velocity.y = jumpHeight * runModifier;
            }
            else if (!isGrounded && !Physics.Raycast(transform.position, -transform.up, glideHeightRay))
            {
                Debug.Log("GLIDEEEEEEEEEEEEEEEEEEEEEEEE");
                isGliding = true;
            }
        }
        c.Move(velocity * Time.deltaTime);

        // Cam holder offset

    }

}
