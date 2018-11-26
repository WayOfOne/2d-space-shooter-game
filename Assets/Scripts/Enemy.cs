using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float health = 100;
    [SerializeField] float shotCount;
    [SerializeField] float projectileSpeed = 5;
    [SerializeField] float min= .2f;
    [SerializeField] float max = 2f;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject deathEffect;
    [SerializeField] float explosionDuration = .5f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0,1)] float soundVolume = 0.6f;


    // Use this for initialization
    void Start () {
        shotCount = Random.Range(min, max);
	}
	
	// Update is called once per frame
	void Update () {
        ShootingRate();
	}

    //randomize firing rate
    private void ShootingRate()
    {
        shotCount -= Time.deltaTime;
        if(shotCount <= 0f)
        {
            Shoot();
            shotCount = Random.Range(min, max);
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage damageDealer = collision.gameObject.GetComponent<Damage>();
        ProcessDamage(damageDealer);
        if (!damageDealer) { return; }
    }

    private void ProcessDamage(Damage damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit(); //destroys the bullet
        //death
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(explosion, explosionDuration);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, soundVolume);

        }
    }
}
