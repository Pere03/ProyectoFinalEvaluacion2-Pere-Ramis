using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMenu : MonoBehaviour
{
   public AudioSource CamaraAudioSource;
   private float musicVolume = 1f;

    void Start()
    {
        //Con esto podemos acceder a la componente AudioSource de la camara
        CamaraAudioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        CamaraAudioSource.volume = musicVolume;
    }

    //Con esto accedemos al volumen del audio source y podemos modificar dicho volumen
    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }
}
