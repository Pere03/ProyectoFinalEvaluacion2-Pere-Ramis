using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectiles : MonoBehaviour
{
    private AudioSource ProyectilAudioSource;
    private PlayerController playerControllerScript;

    public GameObject missilePrefab;
    public AudioClip Fire;
    
    void Start()
    {
        //Con esto podemos acceder al script PlayerController de nuestro player
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        //Con esto podemos acceder a la variable PlayerController de nuestro player
        ProyectilAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!playerControllerScript.GameOver)
        {
            //Esto hace que si pulsamos espacio, instanciara el misil y ademas reproducira el sonido de "Fire"
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                missilePrefab.transform.position = gameObject.GetComponent<Transform>().position;
                missilePrefab.transform.rotation = gameObject.GetComponent<Transform>().rotation;

                Instantiate(missilePrefab, missilePrefab.transform.position, missilePrefab.transform.rotation);

                ProyectilAudioSource.PlayOneShot(Fire);

            }
        }
    }
}
