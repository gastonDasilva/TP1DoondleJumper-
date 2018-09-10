using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public float jumpPower = 8.5f;
    public GameObject game;

    private Rigidbody2D rb2d;
    private Animator anim;
    private bool jump;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>(); // detecta automaticamente el rigidbody
        anim = GetComponent<Animator>();// detecta automaticamente el animator, para gestionar las animaciones
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Speed",Mathf.Abs(rb2d.velocity.x)); // valor absolutod de la velocidad del eje x 
        anim.SetBool("Grounded", grounded);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded) // para saltar con la flecha Arriba
        {
            jump = true;
        }
	}

    void FixedUpdate()
    {
        Vector3 fixedVelocity = rb2d.velocity;// Para corregir la frision provista por el materials 2D
        fixedVelocity.x *= 0.75f;
        float h = Input.GetAxis("Horizontal"); // para detectar la flechas que se aprientan, -1 para <- y 1 para ->

        if (grounded)
        {
            rb2d.velocity = fixedVelocity;
        }

        rb2d.AddForce(Vector2.right * speed * h);

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f,1f,1f);
        }

        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); // Fisica del SALTO
            jump = false;
        }

        game.SendMessage("IncreasePoint", transform.position.y);
    }

     /*void OnBecameInvisible()
    {
        transform.position = new Vector3(-7f, 0f, 0f);    
    }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Debug.Log("Player Ha Muerto");
            game.SendMessage("RestarGame");
        }
        else
        {
            Debug.Log(" NO ENTROO" + transform.gameObject.tag);
            Debug.Log(" NO ENTROO" + collision.gameObject.tag);
        }

    }
}
