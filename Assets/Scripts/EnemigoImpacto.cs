using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoImpacto : MonoBehaviour
{
    private PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!playerControllerScript.GameOver)
        {
            if (otherCollider.collider.tag == "Player")
            {
                playerControllerScript.GameOver = true;
                Destroy(gameObject);
            }
        }
    }
}
