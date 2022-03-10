using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate : MonoBehaviour
{
    public GameObject proyectil;
    private PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnProyectil", 2f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnProyectil()
    {
        if (!playerControllerScript.GameOver)
        {
            Instantiate(proyectil, transform.position, transform.rotation);
        }
    }
}
