using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    
    public Image HealthBar;
    public Image Speedometer;
    Rigidbody rb;
    public float Health = 100;
    public bool livesLeft = true;
    public bool alive = true;
	// Use this for initialization
	void Start () {
        HealthBar.fillAmount = 1;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Speedometer.fillAmount = rb.velocity.magnitude/75;
        HealthBar.fillAmount = Health / 100;
    }

    public void Dead()
    {
        StartCoroutine("Explode");
    }

    void ResetPosition()
    {
        if (livesLeft)
        {
            Health = 100;
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.identity;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            alive = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if(collision.collider.CompareTag("Car"))
        {
            Health -= 10;
            HealthBar.fillAmount = Health / 100;
        }

    }


    void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Grass"))
        {
            Health -= 0.5f;
            HealthBar.fillAmount = Health / 100;
        }
        else if (collider.CompareTag("Spikes"))
        {
            Health -= 1;
            HealthBar.fillAmount = Health / 100;
        }
    }

    IEnumerator Explode()
    {
        foreach (Renderer mat in gameObject.GetComponentsInChildren<Renderer>())
        {
            mat.material.SetColor("_Color", Color.black);
        }
        yield return new WaitForSeconds(0.5f);
        foreach (Renderer mat in gameObject.GetComponentsInChildren<Renderer>())
        {
            mat.material.SetColor("_Color", Color.white);
        }
        ResetPosition();
    }
}
