using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float speedZ;
    public Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 Direction = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Direction += transform.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Direction += -transform.up;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Direction += transform.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Direction += -transform.right;
        }

        if (Direction != Vector3.zero)
        {
            //rigidBody.AddForce(Direction * speed, ForceMode2D.Force);
            if (Input.GetKey(KeyCode.Z))
            {
                rigidBody.velocity = Direction * speedZ;
            }
            else 
            {
                rigidBody.velocity = Direction * speed;
            }
        }
        else
        {
            rigidBody.velocity = Vector3.zero;
        }
        
    }
}
