using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinScore : MonoBehaviour
{
   public int coinValue = 3;

   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.gameObject.CompareTag("Player"))
       {
           ScoreManager.instance.ChangeScore(coinValue);
           
         
       }
   }
}
