using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour {

    public Transform target;
    public float speed;

    private Vector3 start, end;
	// Use this for initialization
	void Start () {
		if (target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (target != null)
        {
            float fixedSpeedDelta = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeedDelta);
            // Estas dos lineas de codigo permiten que la plataforma se mueva
        }

        if (transform.position == target.position)
        {
            target.position = (target.position == start) ? end : start;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Debug.Log("OjitoX2");
            Destroy(transform.gameObject);
        }
        else
        {
            Debug.Log(" NO ENTROO" + transform.gameObject.tag);
            Debug.Log(" NO ENTROO" + collision.gameObject.tag);
        }

    }


    /*void OnBecameInvisible()
    {
        DestroyPlataforma();
    }

    void DestroyPlataforma()
    {
        Destroy(transform.gameObject);
    }*/
}
