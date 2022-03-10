using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiroTorreta : MonoBehaviour
{
    public float turnSpeedH = 50f;
    public float horizontalInput;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(Vector3.forward * turnSpeedH * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(Vector3.back * turnSpeedH * Time.deltaTime);
        }
    }
}
