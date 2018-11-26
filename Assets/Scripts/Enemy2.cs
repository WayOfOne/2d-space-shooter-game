using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//bigger slower enemy bullets that can also go diagonal
public class Enemy2 : MonoBehaviour {

    [SerializeField] float health = 200;
    [SerializeField] float shotCount;
    [SerializeField] float projectileSpeed = 5;
    [SerializeField] float min = .2f;
    [SerializeField] float max = 2f;
    [SerializeField] GameObject projectile;

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
        ProcessDamage(damageDealer);
    }

    private void ProcessDamage(Damage damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);

        }
    }
}
