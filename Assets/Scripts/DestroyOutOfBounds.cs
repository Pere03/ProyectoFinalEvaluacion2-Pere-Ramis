using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float xPosLim = 118;
    private float xNegLim = -129;
    private float zPosLim = 94;
    private float zNegLim = -123;
    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {

        /*

        //Limite de la posicion X en el que se destruira
        if (transform.position.x > xPosLim)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < xNegLim)
        {
            Destroy(gameObject);
        }

        //Limite de la posicion Z en el que se destruira
        if (transform.position.z > zPosLim)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < zNegLim)
        {
            Destroy(gameObject);
        }
        */

    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.collider.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    /*
    private void OnColliderEnter(Collider otherCollider)
    {
        if (!playerControllerScript.GameOver)
        {
            if (otherCollider.collider.tag == "Wall")
            {
                Destroy(gameObject);
            }
        }
    }
    */
}
