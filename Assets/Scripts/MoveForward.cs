using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public float speed = 10f;

    void Start()
    {
        //Con esto podemos acceder al script PlayerController de nuestro player
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if (!playerControllerScript.GameOver)
        {
            //Esto hace que cualquiera que tenga este script avanzara hacia delante segun la velocidad que tenga asignada
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
