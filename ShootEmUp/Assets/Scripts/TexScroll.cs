using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexScroll : MonoBehaviour {

    public float scrollSpeedY;
    Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float offset = Time.time * scrollSpeedY;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
	}
}
