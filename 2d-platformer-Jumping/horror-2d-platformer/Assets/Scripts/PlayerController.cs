using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private bool faceRight = true;
    private bool isRunning = false;
    public bool isGrounded = false;
    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);

        // Button toggle for walking and running
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightControl))
        {
            if (isRunning)
            {
                speed -= 5.0f;
            }
            else
            {
                speed += 5.0f;
            }

            isRunning = !isRunning;
        }

        // If moving Left
        if (Input.GetAxisRaw("Horizontal") < 0.0f)
        {
            if (faceRight)
            {
                Flip();
            }
        }
        // If moving Right
        else if (Input.GetAxisRaw("Horizontal") > 0.0f)
        {
            if (!faceRight)
            {
                Flip();
            }
        }

        transform.position += horizontal * speed * Time.deltaTime;

        Jump();
    }

    /*
     Custom functions
    */

    // Flips animation and sets faceRight bool, possibly good for later use
    void Flip()
    {
        faceRight = !faceRight;
        animator.transform.Rotate(0, 180, 0);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 15f), ForceMode2D.Impulse);
        }
    }
}
