using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaJugador : MonoBehaviour
{

    public int maxVida = 100;
    public int vidaActual;

    public BarraVida barraVida;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = maxVida;
        barraVida.setMaxVida(maxVida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void dañoSufrido(int daño)
    {
        vidaActual -= daño;
        barraVida.setVida(vidaActual);

    }
}
