using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private int NoneEnemys;
    private Rigidbody PlayerRigidBody;
    private float stopMovementTimer;
    private float movementTimeLeft;

    public float Speed;
    public float rotateSpeed;
    public bool GameOver;
    public ParticleSystem ExplosionParticleSystem;
    public GameObject GameOverC;
    public TextMeshProUGUI Texto;

    void Start()
    {
        GameOver = false;
        PlayerRigidBody = GetComponent<Rigidbody>();
        movementTimeLeft = stopMovementTimer;
        GameOverC.SetActive(false);
    }

    void Update()
    {
        if (!GameOver)
        {
            controlCharacter();
        }

        NoneEnemys = FindObjectsOfType<Enemigo>().Length;

        if (NoneEnemys <= 0)
        {
            Debug.Log("Has ganado");
        }

        Texto.text = $"{NoneEnemys}";
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
                //Destroy(gameObject);
                Destroy(otherCollider.gameObject);
                GameOverC.SetActive(true);
                Vector3 offset = new Vector3(0, 0, 0);
                var inst = Instantiate(ExplosionParticleSystem, transform.position + offset, ExplosionParticleSystem.transform.rotation);
                inst.Play();
            }
        }
    }
}
