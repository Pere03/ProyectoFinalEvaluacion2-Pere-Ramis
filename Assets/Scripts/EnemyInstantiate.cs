using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate : MonoBehaviour
{
    public GameObject proyectil;
    private PlayerController playerControllerScript;
    void Start()
    {
        //Con esto podemos acceder al script PlayerController de nuestro player
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        //Esto invocara de forma repetida el "SpawnProyectil" cada 4 segundos
        InvokeRepeating("SpawnProyectil", 2f, 4f);
    }


    public void SpawnProyectil()
    {
        if (!playerControllerScript.GameOver)
        {
            //Esto hace que se instancie el prefab del proyectil
            Instantiate(proyectil, transform.position, transform.rotation);
        }
    }
}
