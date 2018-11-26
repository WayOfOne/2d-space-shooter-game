using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    float backgroundSpeed = .01f;
    Material material;
    Vector2 offset;
	// Use this for initialization
	void Start () {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(0f, backgroundSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        material.mainTextureOffset += offset * Time.deltaTime;
	}
}
