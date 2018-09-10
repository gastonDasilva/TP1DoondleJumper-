using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformGroud : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Debug.Log("OjitoX3");
            Destroy(transform.gameObject);
        }
        else
        {
            Debug.Log(" NO ENTROO" + transform.gameObject.tag);
            Debug.Log(" NO ENTROO" + collision.gameObject.tag);
        }

    }
}
