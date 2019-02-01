using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed, lifetime;
    public GameObject explosionPrefab;
    public GameObject soundObject;
    public int damage;
	// Use this for initialization
	void Start () {
        Invoke("DestroyProjectile", lifetime);
        Instantiate(soundObject, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.up * speed * Time.deltaTime);	
	}

    void DestroyProjectile()
    {
        Instantiate(explosionPrefab,transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            DestroyProjectile();
        }
        if (collision.tag == "Boss")
        {
            collision.GetComponent<Boss>().TakeDamage(damage);
            DestroyProjectile();
        }
    }
}
