using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private Rigidbody EnemigoRigidBody;
    

    void Start()
    {
        EnemigoRigidBody = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        
            if (otherCollider.collider.tag == "ProyectilPlayer")
            {
                Destroy(gameObject);
                Destroy(otherCollider.gameObject);
            }
        
    }
}
