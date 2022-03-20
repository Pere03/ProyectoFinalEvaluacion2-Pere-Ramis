using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public AudioSource CamaraAudioSource;

    void Start()
    {
        //Con esto podemos acceder a la componente AudioSource de la camara
        CamaraAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
