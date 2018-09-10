using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject follow;
    public Vector2 minCamPos, maxCamPos;
    public float smothTime;

    private Vector2 velocity;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float posY = Mathf.SmoothDamp(transform.position.y, 
                                      follow.transform.position.y, 
                                      ref velocity.y, 
                                      smothTime); //follow.transform.position.y;

        transform.position = new Vector3(transform.position.x, 
            Mathf.Clamp(posY, minCamPos.y, maxCamPos.y), 
            transform.position.z);
		
	}
}
