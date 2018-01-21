using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

   public void GetHit(int PlayerDamage)
    {
        int totalDamage = PlayerDamage + Random.Range(30, 40);
        Debug.Log(totalDamage);
        
    }
}
