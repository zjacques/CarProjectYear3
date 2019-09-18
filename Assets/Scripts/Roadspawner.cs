using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roadspawner : MonoBehaviour {

    public GameObject road;
    bool spent;

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.CompareTag("Player") && !spent)
        {
            spent = true;
            Instantiate(road, new Vector3(transform.position.x, transform.position.y, transform.position.z+150), transform.rotation);
        }
    }

}
