using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSounds : MonoBehaviour {
    private AudioSource source;
    public AudioClip[] clips;
    public float timeBetweenEffects;
    private float nextSoundEffectsTime;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if(Time.time >= nextSoundEffectsTime)
        {
            int random = Random.Range(0, clips.Length);
            source.clip = clips[random];
            source.Play();
            nextSoundEffectsTime = Time.time + timeBetweenEffects;
        }
    }
}
