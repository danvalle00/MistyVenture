using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistyCollectCoin : MonoBehaviour
{
   
 

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "GoldCoin" || other.gameObject.tag == "SilverCoin" || other.gameObject.tag == "BronzeCoin"){
            Destroy(other.gameObject);
        }
    }

  
}
