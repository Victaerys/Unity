using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sr;

    public float velocidad = 5f;
    public float sprint = 5f;
    public float fuerzaSalto = 5f;
    private bool tocaSuelo = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        tocaSuelo = false;
    }

    // Update is called once per frame
    void Update()
    {
        float movimiento = Input.GetAxis("Horizontal");
        if (movimiento != 0) {

            animator.SetBool("estaCorriendo", true);
            sr.flipX = movimiento < 0;

            if (Input.GetKey(KeyCode.LeftShift))
                rb.velocity = new Vector2((velocidad + sprint) * movimiento, rb.velocity.y);
            else
                rb.velocity = new Vector2(velocidad * movimiento, rb.velocity.y);
          
        }
        else animator.SetBool("estaCorriendo", false);

        if (Input.GetKey(KeyCode.Space) && tocaSuelo==true)
        {
            
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        }
  
}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma")
        {
            tocaSuelo = true;
            animator.SetBool("estaSaltando", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma")
        {
            tocaSuelo = false;
            animator.SetBool("estaSaltando", true);
        }
    }

}
