using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectiles : MonoBehaviour
{
    public GameObject missilePrefab;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
