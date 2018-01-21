using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveBytexScreen : MonoBehaviour {

    GameManager GM;

    void Start()
    {
        GM = FindObjectOfType<GameManager>();

    }

    void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "Computer")
        {
            Debug.Log("Time to leave");
            GM.FP.SetActive(true);
            GM.TD.SetActive(false);
        }
    }
}
