using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    //[Range(0.01f,1f)]
    //public float damper = 0.01f;

    public float moveSpeedX, moveSpeedY;

    Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        var move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        rb2d.velocity = new Vector2(move.x * moveSpeedX, move.y * moveSpeedY);/* * damper*/;

	}
}
