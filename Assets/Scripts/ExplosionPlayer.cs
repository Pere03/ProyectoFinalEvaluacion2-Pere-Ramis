using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPlayer : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public ParticleSystem ExplosionParticleSystem;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!playerControllerScript.GameOver)
        {
            if (otherCollider.collider.tag == "ProyectilEnemigo")
            {
                ExplosionParticleSystem.Play();
            }
        }
    }

}
