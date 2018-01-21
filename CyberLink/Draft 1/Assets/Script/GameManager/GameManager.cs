using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject FP;
    public GameObject TD;
    public Canvas DirencCanvas;

    void Start()
    {
        FP.SetActive(true);
        TD.SetActive(false);
        DirencCanvas.enabled = true;

    }
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit Hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out Hit))
            {
                if (Hit.collider.tag == "Computer")
                {
                    FP.SetActive(false);
                    TD.SetActive(true);
                    DirencCanvas.enabled = false;
                }
            }

        }
    }
}
