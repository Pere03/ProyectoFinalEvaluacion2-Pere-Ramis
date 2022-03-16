using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public ParticleSystem ExplosionParticleSystem;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {

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
}
