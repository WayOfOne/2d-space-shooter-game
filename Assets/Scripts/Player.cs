﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Player")]
    [SerializeField] int health = 1000;
    [SerializeField] float speed = 5f;
    [SerializeField] float xPadding = .2f;
    [SerializeField] float topYPadding = 1f;
    [SerializeField] float bottomYPadding = .2f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip laserSound;
    [SerializeField] AudioClip shieldSound;
    [SerializeField] [Range(0, 1)] float deathVolume = 0.6f;
    [SerializeField] [Range(0, 1)] float laserVolume = 0.1f;
    [SerializeField] [Range(0, 1)] float shieldVolume = 0.6f;

    [Header("laser")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float laserSpeed = 10f;
    [SerializeField] float firingRate = 0.05f;
    Coroutine shootCoroutine;

    float xMin, xMax, yMin, yMax;

	// Use this for initialization
	void Start () {
        SetBoundary();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Shoot();
	}

    public int GetHP()
    {
        return health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage damageDealer = collision.gameObject.GetComponent<Damage>();
        //checking if there's a damage dealer
        if (!damageDealer)
        {
            return;
        }
        ProcessDamage(damageDealer);
    }

    private void ProcessDamage(Damage damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit(); //destroys the bullet 
        AudioSource.PlayClipAtPoint(shieldSound, Camera.main.transform.position, shieldVolume);
        //death, destroy gameobject, create explosion particle and play death sound
        if (health <= 0)
        {
            FindObjectOfType<Level>().LoadGameOver();
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathVolume);
        }
    }

    //shoot continously when the fire button is held down
    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shootCoroutine = StartCoroutine(ShootContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            //StopAllCoroutines();
            StopCoroutine(shootCoroutine);

        }
    }

    //coroutine to keep shooting
    IEnumerator ShootContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserVolume);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            yield return new WaitForSeconds(firingRate);
        }
    }

    //set the boundary so that the player ship doesn't move off the camera screen
    private void SetBoundary()
    {
        //ViewPortToWorldPoint() to convert poisition of something as it relates to camera view
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xPadding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xPadding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + bottomYPadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - topYPadding;
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
