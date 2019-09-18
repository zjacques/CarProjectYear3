using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour {

    Rigidbody rb;

    public GameObject shot;
    bool left = true;
    public Transform mg1;
    public Transform mg2;
    public float fireRate;

    private float nextFire;
    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponentInParent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetButton("Fire1") || Input.GetButton("Jump")) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //Determines if the left or right machine gun should shoot next
            if(left)
            {
                GameObject bullet = Instantiate(shot, mg1.position, mg1.rotation);
                bullet.GetComponent<Mover>().speed = rb.velocity.magnitude + 50;
                left = false;
            }
            else
            {
                GameObject bullet = Instantiate(shot, mg2.position, mg2.rotation);
                bullet.GetComponent<Mover>().speed = rb.velocity.magnitude + 50;
                left = true;
            }


        }
    }
}
