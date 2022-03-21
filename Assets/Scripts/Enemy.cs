using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public ParticleSystem HumoParticleSystem;
    public ParticleSystem ExplosionParticleSystem;

    private void OnCollisionEnter(Collision otherCollider)
    {
        //Si un proyectil enemigo colisiona con el enemigo, se hara todo lo siguiente
        if (otherCollider.gameObject.CompareTag("ProyectilPlayer"))
        {
            //Se destruira tanto el proyectil como el enemigo
            Destroy(otherCollider.gameObject);
            Destroy(gameObject);

            //Se reproduciran unas particulas de humo
            Vector3 offset = new Vector3(0, 0, 0);
            var inst = Instantiate(HumoParticleSystem, transform.position + offset, HumoParticleSystem.transform.rotation);
            inst.Play();

            //Se reproduciran unas particulas de explosion
            Vector3 offsete = new Vector3(0, 0, 0);
            var insta = Instantiate(ExplosionParticleSystem, transform.position + offsete, ExplosionParticleSystem.transform.rotation);
            insta.Play();
        }
    }
}
