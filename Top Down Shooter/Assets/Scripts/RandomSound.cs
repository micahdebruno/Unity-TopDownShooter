using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour {

    private AudioSource source;
    public AudioClip[] clips;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        int random = Random.Range(0, clips.Length);
        source.clip = clips[random];
        source.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
