using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sonido
{
    public string nombre;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volumen;
    [Range(.1f, 3f)]
    public float tono;
    public bool bucle;

    [HideInInspector]
    public AudioSource fuente;

}
