using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{

    public Slider slider;

    public void setMaxVida(int vida)
    {
        slider.maxValue = vida;
        slider.value = vida;
    }

   public void setVida(int vida)
    {
        slider.value = vida;
    }

    
}
