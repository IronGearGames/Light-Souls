using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Animator animator;
    public bool faceRight = true;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        // If facing Right and moving Left
        if (Input.GetAxisRaw("Horizontal") < 0.0f && faceRight)
        {
            Flip();
        }
        // If facing Left and moving Right
        else if (Input.GetAxisRaw("Horizontal") > 0.0f && !faceRight)
        {
            Flip();
        }

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime;
    }

    // Flips animation and sets faceRight bool, possibly good for later use
    void Flip()
    {
        faceRight = !faceRight;
        animator.transform.Rotate(0, 180, 0);
    }
}
