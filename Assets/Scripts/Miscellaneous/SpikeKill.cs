using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeKill : MonoBehaviour
{
    public GameObject misty;
    public Transform respawnPoint;
    private MistyHurting hurtScript;
    private ScoreManager scoreManager;

    
    
    // Start is called before the first frame update
    void Start()
    {
        misty = GetComponent<GameObject>();
        respawnPoint = GetComponent<Transform>();
        hurtScript = GetComponent<MistyHurting>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            misty.transform.position = respawnPoint.position;
            Debug.Log("Misty morreu");
        }
    }
}
