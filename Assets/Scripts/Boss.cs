using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float speed;
    public float staypositiontimemin;
    public float staypositiontimemax;
    private bool CanMove;
    public int hitpoints;
    public WallComponent Wall;
    private Vector2 Destination;
    private BoxCollider2D Collider;

    // Start is called before the first frame update
    void Start()
    {
        CanMove = true;
        rigidBody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();
        //rigidBody.velocity = new Vector2(UnityEngine.Random.Range(-speed, speed), UnityEngine.Random.Range(-speed, speed));
        Wall = FindFirstObjectByType<WallComponent>();
        Destination = Wall.GetRandomPointWithinWallBoundaries(Collider.bounds);
        SetVelocityForTargetLocation(Destination);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Destination) < 0.05 && CanMove)
        {
            rigidBody.velocity = Vector2.zero;
            StartCoroutine(PositionWaitTime());
            CanMove = false;
        }
    }

    IEnumerator PositionWaitTime()
    {
        yield return new WaitForSeconds(Random.Range(staypositiontimemin, staypositiontimemax));
        CanMove = true;
        Destination = Wall.GetRandomPointWithinWallBoundaries(Collider.bounds);
        SetVelocityForTargetLocation(Destination);
        Debug.DrawLine(rigidBody.position, Destination, Color.red, 10, false);
        yield return null;
    }

    private void SetVelocityForTargetLocation(Vector2 Target)
    {
        Vector2 Direction = Target - ((Vector2)transform.position);
        rigidBody.velocity = Direction.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Destroy(collision.gameObject);
            --hitpoints;
            if(hitpoints <= 0)
            {
                //win
            }
        }
    }
}
