using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour {

    public Transform playerTransform;
    public float speed;

    public float minX, minY, maxX, maxY;

	// Use this for initialization
	void Start () {
        transform.position = playerTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerTransform != null)
        {
            float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(playerTransform.position.y, minY, maxY);
            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX,clampedY), speed);
        }
	}
}
