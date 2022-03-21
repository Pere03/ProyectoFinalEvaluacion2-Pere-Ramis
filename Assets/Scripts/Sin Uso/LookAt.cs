using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Enemy");
    }

    
    void Update()
    {
        transform.LookAt(Player.transform.position);
    }
}
