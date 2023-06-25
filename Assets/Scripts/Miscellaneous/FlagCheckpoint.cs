using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCheckpoint : MonoBehaviour
{
    private MistyHurting hurtScript;
    void Start()
    {
        hurtScript = GetComponent<MistyHurting>();
    }
    // N TO CONSEGUIDNO MANDAR A POSIÇÃO DELE PRO OUTRO SCRIPT VOU FICAR DEVEDNDO
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("abuble abuble testando");
            hurtScript.checkpointHandler(transform.position);
        }
    }*/
}
