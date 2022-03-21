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
    private AudioSource PlayerAudioSource;
    private Camara MainCamara;

    public float Speed;
    public float rotateSpeed;
    public bool GameOver;
    public GameObject GameOverC;
    public GameObject WinC;
    public TextMeshProUGUI Texto;
    public AudioClip GameOverMus;
    public AudioClip WinMus;
    

    void Start()
    {
        Time.timeScale = 1;
        GameOver = false;

        //Con esto podemos acceder a la componente AudioSource del player, y la guardamos en playerAudioSource
        PlayerAudioSource = GetComponent<AudioSource>();

        //Con esto podemos acceder a la componente Rigidbody del player, y la guardamos en playerAudioSource
        PlayerRigidBody = GetComponent<Rigidbody>();

        //Con esto podemos acceder al script Camara de nuestra Camara
        MainCamara = GameObject.Find("Camara").GetComponent<Camara>();

        movementTimeLeft = stopMovementTimer;

        GameOverC.SetActive(false);
        WinC.SetActive(false);
    }

    void Update()
    {
       
        if (!GameOver)
        {
            controlCharacter();
        }

        NoneEnemys = FindObjectsOfType<Enemy>().Length;

        //Si el numero de enemigos baja a 0, se reproducira el sonido de win, se activara el menu de Win y se parara tanto la musica de fondo como el tiempo
        if (NoneEnemys == 0)
        {
            PlayerAudioSource.PlayOneShot(WinMus, 0.2f);
            WinC.SetActive(true);
            MainCamara.CamaraAudioSource.Stop();
            Time.timeScale = 0;
            
        }

        Texto.text = $"{NoneEnemys}";
    }

    void controlCharacter()
    {
        if (!GameOver)
        {
            PlayerRigidBody.angularVelocity = Vector3.zero;

            //Si pulsamos la tecla W o la tecla S, el player ira hacia delante o hacia atras
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

            //Si pulsamos la tecla D o la tecla A, el player girara hacia un lado o el otro
            if (Input.GetKey(KeyCode.D))
            {
                PlayerRigidBody.transform.RotateAround(PlayerRigidBody.transform.position, PlayerRigidBody.transform.up, Time.deltaTime * rotateSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                PlayerRigidBody.transform.RotateAround(PlayerRigidBody.transform.position, PlayerRigidBody.transform.up, (Time.deltaTime * rotateSpeed) * -1);
            }

            //Con esto conseguimos que el player se detenga cuando dejamos de pulsar las teclas
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
            //Si un proyectil enemigo colisiona con el player, se hara todo lo siguiente
            if (otherCollider.collider.tag == "ProyectilEnemigo")
            {
               //Se activara el game over, el menu de game over y se destruya el proyectil enemigo
                GameOver = true;
                Destroy(otherCollider.gameObject);
                GameOverC.SetActive(true);

                //Se parara la musica de fondo y se reproducira el sonido de game over
                PlayerAudioSource.PlayOneShot(GameOverMus, 1f);
                MainCamara.CamaraAudioSource.Stop();
            }
        }
    }
}
