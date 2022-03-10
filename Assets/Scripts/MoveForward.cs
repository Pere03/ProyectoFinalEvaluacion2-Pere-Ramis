using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public float speed = 10f;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if (!playerControllerScript.GameOver)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
