using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float lifeTime = 2f;
    private GameManager gamaManagerScript;
    void Start()
    {
        //Autodestruccion tras 2 segundos
        Destroy(gameObject, lifeTime);
        gamaManagerScript = FindObjectOfType<GameManager>();
    }


    void Update()
    {

    }

    private void OnMouseDown()
    {
        Destroy(gameObject);

        if (gameObject.CompareTag("Bad"))
        {
            gamaManagerScript.isGameOver = true;
        }
    }

    private void OnDestroy()
    {
        gamaManagerScript.targetPositions.Remove(transform.position);
    }
  
}
