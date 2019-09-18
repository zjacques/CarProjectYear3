using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    GameController gc;
    public bool isEnemy;
    public int Health;
	// Use this for initialization
	void Start () {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Health<=0)
        {
            //civilians and enemies use this same script, but enemies will add to the player's
            //score and civilians will keep the player from gaining, so they have a setting to
            //tell the gamecontroller which they are when they die
            if (isEnemy)
            {
                gc.EnemyDestroyed();
            }
            else
            {
                gc.CivilianDestroyed();
            }
            StartCoroutine("Explode");
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        Health -= 20;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shot"))
        {
            Health -= 10;
        }
    }

    IEnumerator Explode()
    {
        //When the car dies, it turns black for a tenth of a second before disappearing
        //it looks nicer
        foreach (Renderer mat in gameObject.GetComponentsInChildren<Renderer>())
        {
            mat.material.SetColor("_Color", Color.black);
        }
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

}
