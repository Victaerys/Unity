using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class vidaJugador : MonoBehaviour
{

    public float maxVida = 100f;
    public float vidaActual;
    public Animator animator;

    public float dañoPinchos = 10f;
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
        vidaActual -= daño;
        barraVida.setVida(vidaActual);

    }

    private async void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pinchos")
        {
            dañoSufrido(dañoPinchos);
            rb.velocity = new Vector2(rb.velocity.x, fuerzaDaño);
            animator.SetTrigger("estaSiendoDañado");
        }
    }

}
