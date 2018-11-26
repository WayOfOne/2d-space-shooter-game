using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float speed = 5f;
    [SerializeField] float yPadding = 3f, xPadding = .5f;

    float xMin, xMax, yMin, yMax;

	// Use this for initialization
	void Start () {
        SetBoundary();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    //set the boundary so that the player ship doesn't move off the camera screen
    private void SetBoundary()
    {
        //ViewPortToWorldPoint() to convert poisition of something as it relates to camera view
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xPadding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xPadding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yPadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - yPadding;
    }

    //moving the player ship alone the x and y axis using the input arrows or wasd
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime *speed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        //clamps the x and y position between the x and y min max values
        var newXPosition = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPosition = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPosition, newYPosition);
    }

    
}
