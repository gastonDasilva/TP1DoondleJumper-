using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaRompible : MonoBehaviour {


    private float fallDelay = 1f;
    private float destroyDelay = 3f;
    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;
    // Use this for initialization
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
            Invoke("DestroyPlataforma", destroyDelay);
            Debug.Log("OJOO TOCO EHHHH");
        }
    } 

    void DestroyPlataforma()
    {
        Destroy(transform.gameObject);
    }
    void Fall()
    {
        rb2d.isKinematic = false;
        bc2d.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Debug.Log("Ojito");
            Destroy(transform.gameObject);
        }
        else
        {
            Debug.Log(" NO ENTROO" + transform.gameObject.tag);
            Debug.Log(" NO ENTROO" + collision.gameObject.tag);
        }

    }
}
