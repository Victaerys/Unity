using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sonido[] sonidos;

    private void Awake()
    {
        foreach(Sonido s in sonidos)
        {
            s.fuente = gameObject.AddComponent<AudioSource>();
            s.fuente.clip = s.clip;
            s.fuente.volume = s.volumen;
            s.fuente.pitch = s.tono;
            s.fuente.loop = s.bucle;
        }
    }

    public void Reproducir (string nombre)
    {
        Sonido s = Array.Find(sonidos, sonido => sonido.nombre == nombre);
        s.fuente.Play();
    }
}
