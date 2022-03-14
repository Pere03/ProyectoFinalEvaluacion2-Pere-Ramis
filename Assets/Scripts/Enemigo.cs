using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    public ParticleSystem HumoParticleSystem;
    public ParticleSystem ExplosionParticleSystem;


    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnCollisionEnter(Collision otherCollider)
    {

        if (otherCollider.gameObject.CompareTag("ProyectilPlayer"))
        {
            Destroy(otherCollider.gameObject);
            Destroy(gameObject);
            Vector3 offset = new Vector3(0, 0, 0);
            var inst = Instantiate(HumoParticleSystem, transform.position + offset, HumoParticleSystem.transform.rotation);
            inst.Play();

            Vector3 offsete = new Vector3(0, 0, 0);
            var insta = Instantiate(ExplosionParticleSystem, transform.position + offsete, ExplosionParticleSystem.transform.rotation);
            insta.Play();
        }
    }
}
