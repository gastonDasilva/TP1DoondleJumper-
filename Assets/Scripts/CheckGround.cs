using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {


    private PlayerController player;
    private Rigidbody2D rb2d;


	// Use this for initialization
	void Start () {
        player = GetComponentInParent<PlayerController>();
        rb2d = GetComponentInParent<Rigidbody2D>();

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Plataform")
        {
            rb2d.velocity = new Vector3(0f, 0f, 0f);
            player.transform.parent = col.transform;
            player.grounded = true;
        }     
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Rompible")
        {
            Debug.Log("OJOO TOCO Ground");
            player.grounded = true;
        }

        if (collision.gameObject.tag == "Plataform")
        {
            player.transform.parent = collision.transform;
            player.grounded = true;
            Debug.Log("OJOO TOCO Plataforma");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" )
        {
            player.grounded = false;
        }

        if (collision.gameObject.tag == "Plataform")
        {
            player.transform.parent = null;
            player.grounded = false;
        }

        if (collision.gameObject.tag == "Rompible")
        {
            player.grounded = false;
            //Destroy(collision.gameObject);
        }

    }

}
