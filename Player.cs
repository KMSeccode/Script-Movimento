using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forcaPulo;
    public float velocidadeMaxima;
    void Start()
    {

    }

    void FixedUpdate()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        float movimento = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector2(movimento * velocidadeMaxima, rigidbody.velocity.y);

        if (movimento < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (movimento > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

            if (movimento > 0 || movimento < 0)
        {
            GetComponent<Animator>().SetBool("walking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("walking", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector2(0, forcaPulo));
        }

    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Plataformas")) ;
        {
            forcaPulo = 160;

            GetComponent<Animator>().SetBool("jump", false);
        }

        Debug.Log("Colidiu!" + collision2D.gameObject.tag);

    }

    void OnCollisionExit2D(Collision2D collision2D)
    {

        if (collision2D.gameObject.CompareTag("Plataformas")) ;
        {
            forcaPulo = 0;

            GetComponent<Animator>().SetBool("jump", true);
        }



        Debug.Log("Parou de Colidir!" + collision2D.gameObject.tag);
    }

}