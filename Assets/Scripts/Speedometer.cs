﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour {

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(rb.velocity.magnitude);
	}
}
