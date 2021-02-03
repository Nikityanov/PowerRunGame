using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float[] rows = new float[] { -1.5f, 0, 1.5f };     // x position of each row
    public int targetRow = 1;
    public int moveSpeed = 10;
    public Rigidbody rb;
    public float jumpPower = 1;
    public Animator ac;
    public bool isGrounded = true;
    public SwipeManager sm;

    private void Start()
    {
      
    }

    void Update()
    {

        if (sm.swipe[0] && targetRow > 0)
        {
            targetRow--;
            sm.Reset();
        }

        if (sm.swipe[1] && targetRow < rows.Length - 1)
        {
            targetRow++;
            sm.Reset();
        }
        if (sm.swipe[2] && isGrounded == true)
        {
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            isGrounded = false;
            ac.SetTrigger("Jumping");
        }
        if (sm.swipe[3] && isGrounded == false)
        {
            rb.AddForce(new Vector3(0, -jumpPower*0.1f, 0), ForceMode.Impulse);
        }

        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(rows[targetRow], transform.position.y, transform.position.z), moveSpeed * Time.deltaTime);
        }
    }
}
