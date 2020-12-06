using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class vidaJugador : MonoBehaviour
{

    public float maxVida = 100f;
    public float vidaActual;
    public Animator animator;

    public float dañoPinchos = 10f;
    public float vidaCerezas = 5f;
    public float fuerzaDaño = 6.5f;

    public Rigidbody2D rb;

    public BarraVida barraVida;

    private static System.Timers.Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = maxVida;
        barraVida.setMaxVida(maxVida);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dañoSufrido(float daño)
    {
        FindObjectOfType<AudioManager>().Reproducir("Daño");
        vidaActual -= daño;
        barraVida.setVida(vidaActual);

    }

    public void vidaRecuperada(float vida)
    {
        if(vida + vidaActual <= maxVida)
        {
            vidaActual += vida;
        } else
        {
            vidaActual = maxVida;
        }

        barraVida.setVida(vidaActual);

    }

    private async void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pinchos")
        {
            FindObjectOfType<AudioManager>().Reproducir("Pinchar");
            dañoSufrido(dañoPinchos);
            rb.velocity = new Vector2(rb.velocity.x, fuerzaDaño);
            animator.SetTrigger("estaSiendoDañado");
        } 
        else if (collision.gameObject.tag == "Cereza")
        {
            FindObjectOfType<AudioManager>().Reproducir("Comer");
            vidaRecuperada(vidaCerezas);
            Destroy(collision.gameObject);
        }
    }

}
