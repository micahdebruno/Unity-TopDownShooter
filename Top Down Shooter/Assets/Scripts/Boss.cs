using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    public int health;
    public Enemy[] enemies;
    public float spawnOffset;
    public int damage;
    public GameObject effect, blood;

    private int halfHealth;
    private Animator anim;
    private Slider healthBar;
    private SceneTransitions sceneTransitions;

	// Use this for initialization
	void Start () {
        halfHealth = health / 2;
        anim = GetComponent<Animator>();
        healthBar = FindObjectOfType<Slider>();
        healthBar.maxValue = health;
        healthBar.value = health;
        sceneTransitions = FindObjectOfType<SceneTransitions>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        healthBar.value = health;
        if (health <= 0)
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            healthBar.gameObject.SetActive(false);
            sceneTransitions.LoadScene("Win");
        }
        if (health <= halfHealth)
        {
            anim.SetTrigger("Stage2");
        }
        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randomEnemy, transform.position + new Vector3(spawnOffset,spawnOffset), transform.rotation);
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            col.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
