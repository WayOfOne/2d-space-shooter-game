using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//bigger slower enemy bullets that can also go diagonal
public class Enemy2 : MonoBehaviour {

    [Header("Stats")]
    [SerializeField] float health = 100;
    [SerializeField] int value = 200;

    [Header("Shooting")]
    [SerializeField] float shotCount;
    [SerializeField] float projectileSpeed = 5;
    [SerializeField] float min = .2f;
    [SerializeField] float max = 2f;

    [Header("SFX/VFX")]
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject deathEffect;
    [SerializeField] float explosionDuration = .5f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float soundVolume = 0.6f;

    // Use this for initialization
    void Start()
    {
        shotCount = Random.Range(min, max);
    }

    // Update is called once per frame
    void Update()
    {
        ShootingRate();
    }

    //randomize firing rate
    private void ShootingRate()
    {
        shotCount -= Time.deltaTime;
        if (shotCount <= 0f)
        {
            Shoot();
            shotCount = Random.Range(min, max);
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bullet.transform.position.x + Random.Range(-1f, .1f), -projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage damageDealer = collision.gameObject.GetComponent<Damage>();
        if (!damageDealer) { return; }
        ProcessDamage(damageDealer);
    }

    private void ProcessDamage(Damage damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit(); //destroys the bullet
        //death, destroy gameobject, create explosion particle and play death sound
        if (health <= 0)
        {
            //increase score
            FindObjectOfType<GameSession>().addScore(value);

            Destroy(gameObject);
            GameObject explosion = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(explosion, explosionDuration);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, soundVolume);
        }
    }
}
