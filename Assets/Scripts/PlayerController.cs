using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRigidBody;
    public float Speed;
    private float stopMovementTimer;
    private float movementTimeLeft;
    public float rotateSpeed;
    public bool GameOver;
    public ParticleSystem ExplosionParticleSystem;

    void Start()
    {
        PlayerRigidBody = GetComponent<Rigidbody>();
        movementTimeLeft = stopMovementTimer;

    }

    void Update()
    {
        if (!GameOver)
        {
            controlCharacter();
        }
    }

    void controlCharacter()
    {
        if (!GameOver)
        {
            PlayerRigidBody.angularVelocity = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                PlayerRigidBody.AddForce(gameObject.transform.forward * Speed);
                movementTimeLeft = stopMovementTimer;
            }
            if (Input.GetKey(KeyCode.S))
            {
                PlayerRigidBody.AddForce((gameObject.transform.forward * -1) * Speed);
                movementTimeLeft = stopMovementTimer;
            }

            //Rotational Movement
            if (Input.GetKey(KeyCode.D))
            {
                PlayerRigidBody.transform.RotateAround(PlayerRigidBody.transform.position, PlayerRigidBody.transform.up, Time.deltaTime * rotateSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                PlayerRigidBody.transform.RotateAround(PlayerRigidBody.transform.position, PlayerRigidBody.transform.up, (Time.deltaTime * rotateSpeed) * -1);
            }

            //StopMovement
            if (movementTimeLeft <= 0)
            {
                PlayerRigidBody.velocity = new Vector3(0, PlayerRigidBody.velocity.y, 0);
            }
        }    
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!GameOver)
        {
            if (otherCollider.collider.tag == "ProyectilEnemigo")
            {
               
                GameOver = true;
                Destroy(gameObject);
                Destroy(otherCollider.gameObject);
                Vector3 offset = new Vector3(0, 0, 0);
                var inst = Instantiate(ExplosionParticleSystem, transform.position + offset, ExplosionParticleSystem.transform.rotation);
                inst.Play();
            }
        }
    }

 
}
