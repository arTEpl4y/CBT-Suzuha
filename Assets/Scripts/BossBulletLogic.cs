using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletLogic : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.up * speed * Time.deltaTime; //boss attack 1
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) //all of the boss bullets get destroyed when hitting outer walls
        {
            Destroy(this.gameObject);
        }
    }
}
