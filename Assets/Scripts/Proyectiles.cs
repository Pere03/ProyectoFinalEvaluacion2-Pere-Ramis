using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectiles : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public GameObject missilePrefab;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.GameOver)
        {
            //Esto hace que si pulsamos espacio, instanciara el misil
            if (Input.GetKeyDown(KeyCode.Space))
            {
                missilePrefab.transform.position = gameObject.GetComponent<Transform>().position;
                missilePrefab.transform.rotation = gameObject.GetComponent<Transform>().rotation;

                Instantiate(missilePrefab, missilePrefab.transform.position,
                    missilePrefab.transform.rotation);
            }
        }
    }
}
