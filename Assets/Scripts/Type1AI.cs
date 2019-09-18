using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type1AI : MonoBehaviour {

    Rigidbody rb;
    public GameObject player;

    public float speed;

    bool collided = false;
    float collidedTimer = 0;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        Vector3 angleToPlayer = player.transform.position - gameObject.transform.position;
        rb.velocity = angleToPlayer.normalized * speed;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!collided)
        {
            Vector3 angleToPlayer = player.transform.position - gameObject.transform.position;
            rb.velocity = angleToPlayer.normalized * speed;
        }
        else
        {
            collidedTimer += Time.deltaTime;
            if (collidedTimer > 1)
            {
                collided = false;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collided = true;
            rb.velocity *= -1;
        }
    }
}
