using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sr;
    public Transform trans;

    public float velocidad = 5f;
    public float sprint = 5f;
    public float fuerzaSalto = 6.5f;
    [SerializeField] private bool tocaSuelo = false;
    private float ejeYAnterior;
    private float ejeY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        trans = GetComponent<Transform>();
        tocaSuelo = false;
        ejeYAnterior = trans.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        //Correr

        float movimiento = Input.GetAxis("Horizontal");
        if (movimiento != 0) {



            animator.SetBool("estaCorriendo", true);
            sr.flipX = movimiento < 0;

            if (Input.GetKey(KeyCode.LeftShift) && tocaSuelo == true)
                rb.velocity = new Vector2((velocidad + sprint) * movimiento, rb.velocity.y);
            else
                rb.velocity = new Vector2(velocidad * movimiento, rb.velocity.y);
          
        }
        else animator.SetBool("estaCorriendo", false);


        //Saltar y caer

        if (Input.GetKey(KeyCode.Space) && tocaSuelo==true)
        {
            FindObjectOfType<AudioManager>().Reproducir("Salto");
            animator.SetBool("estaSaltando", true);
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        }

        ejeY = trans.position.y;

        if (ejeY < ejeYAnterior && tocaSuelo == false)
        {
            animator.SetBool("estaSaltando", false);
            animator.SetBool("estaCayendo", true);
        } 

        ejeYAnterior = ejeY;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma")
        {
          
            tocaSuelo = true;
            animator.SetBool("estaCayendo", false);
            animator.SetBool("estaSaltando", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma")
        {
            tocaSuelo = false;
        }
    }

}
