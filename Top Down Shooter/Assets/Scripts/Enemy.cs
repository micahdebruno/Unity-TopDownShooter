using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public int damage;
    //[HideInInspector]
    public Transform player;
    public float speed;
    public float timeBetweenAttacks;
    public int pickupChance;
    public int healthPickupChance;
    public GameObject healthPickup;
    public GameObject deathEffect;
    public GameObject[] pickups;
	// Use this for initialization
	public virtual void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            int random = Random.Range(0, 101);
            if(random < pickupChance)
            {
                GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                Instantiate(randomPickup, transform.position, transform.rotation);
            }
            int randHealth = Random.Range(0, 101);
            if(randHealth < healthPickupChance)
            {
                Instantiate(healthPickup, transform.position, transform.rotation);
            }
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
