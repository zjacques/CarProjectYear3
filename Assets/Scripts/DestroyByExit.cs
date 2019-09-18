using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByExit : MonoBehaviour {

    void OnTriggerExit(Collider coll)
    {
        Destroy(coll.gameObject);
    }
}
