using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtWalls : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public ParticleSystem ExplosionParticleSystem;

    void Start()
    {
        //Con esto podemos acceder al script PlayerController de nuestro player
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!playerControllerScript.GameOver)
        { 
            //Si el proyectil colisiona contra un muro, se destruira el proyectil y se reproduciran unas particulas de explosion
            if (otherCollider.collider.tag == "Wall")
            {
                Destroy(gameObject);
                Vector3 offset = new Vector3(0, 0, 0);
                var inst = Instantiate(ExplosionParticleSystem, transform.position + offset, ExplosionParticleSystem.transform.rotation);
                inst.Play();
            }
        }
    }
}
