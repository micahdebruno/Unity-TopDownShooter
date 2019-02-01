using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public Weapon weaponToEquip;
    public GameObject effect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            col.GetComponent<Player>().ChangeWeapon(weaponToEquip);
            Destroy(this.gameObject);
        }
    }
}
