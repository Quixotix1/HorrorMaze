using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    /**
     * CREDIT https://www.youtube.com/watch?v=f473C43s8nE
     * "FIRST PERSON MOVEMENT in 10 MINUTES - Unity Tutorial" by Dave / GameDevelopment
     */
    public float moveSpeed;

    public Transform orientation;

    float inputX;
    float inputZ;

    Vector3 moveDir;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        moveDir = orientation.forward * inputZ + orientation.right * inputX;
        
        rb.AddForce(moveDir.normalized * moveSpeed, ForceMode.Force);

        Vector3 currentVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        float flatReduction = 10f; // artificially reduces movement speed in the following check
        if (currentVelocity.magnitude > moveSpeed / flatReduction)
        {
            Vector3 normalizedVelocity = currentVelocity.normalized * moveSpeed / flatReduction;
            rb.velocity = new Vector3(normalizedVelocity.x, rb.velocity.y, normalizedVelocity.z);
        }
    }
}
