using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator torretaAnim;
    void Start()
    {
        torretaAnim = GameObject.Find("TorretaP").GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            torretaAnim.SetBool("Disparo", true);
        }
    }
}
