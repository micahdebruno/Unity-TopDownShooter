using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

    Player playerScript;
    public int healAmount;
    public GameObject effect;
    // Use this for initialization
    void Start () {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player"){
            Instantiate(effect, transform.position, Quaternion.identity);
            playerScript.Heal(healAmount);
            Destroy(this.gameObject);
        }
    }
}
