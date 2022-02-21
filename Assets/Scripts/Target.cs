using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float lifeTime = 2f;
    private GameManager gamaManagerScript;
    public int points;
    public ParticleSystem explosionParticle;
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
        if (!gamaManagerScript.isGameOver)
        {
            gamaManagerScript.UpdateScore(points);

            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            Destroy(gameObject);

            if (gameObject.CompareTag("Bad"))
            {
                gamaManagerScript.GameOver();
            }
        }
    }

    private void OnDestroy()
    {
        gamaManagerScript.targetPositions.Remove(transform.position);
    }
  
}
