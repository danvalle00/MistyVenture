using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCoinScore : MonoBehaviour
{
    public int coinValue = 2;

   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.gameObject.CompareTag("Player"))
       {
           ScoreManager.instance.ChangeScore(coinValue);
           
         
       }
   }

  
}
