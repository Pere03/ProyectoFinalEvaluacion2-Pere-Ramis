using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    /*
    private float xPosLim = 118;
    private float xNegLim = -129;
    private float zPosLim = 94;
    private float zNegLim = -123;
    */
    private PlayerController playerControllerScript;
    public ParticleSystem ExplosionParticleSystem;

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
        if (!playerControllerScript.GameOver)
        { 
            if (otherCollider.collider.tag == "Wall")
            {
                Destroy(gameObject);
                Vector3 offset = new Vector3(0, 0, 0);
                var inst = Instantiate(ExplosionParticleSystem, transform.position + offset, ExplosionParticleSystem.transform.rotation);
                inst.Play();
            }
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
