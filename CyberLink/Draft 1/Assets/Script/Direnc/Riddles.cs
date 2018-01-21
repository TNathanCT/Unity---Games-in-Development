using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Riddles : MonoBehaviour {

    public Animator Anim;
    public bool isOpen;
    public Rigidbody DirencRB;
    public Transform DirencTransform;
    PlayerController PC;
    RotateToMouse TRM;

	
	void Start () {
        isOpen = false;
        Anim = GetComponent<Animator>();
        DirencTransform = DirencTransform.parent;
        DirencRB = DirencTransform.GetComponent<Rigidbody>();
        PC = DirencTransform.GetComponent<PlayerController>();
        TRM = DirencTransform.GetComponent<RotateToMouse>();
        	
	}

	public void Update () {
        if (isOpen == false)
        {
            Anim.SetBool("Open", false);
            PC.enabled = true;
            TRM.enabled = true;
     
        }
        if (isOpen == true)
        {
            Anim.SetBool("Open", true);
            PC.enabled = false;
            TRM.enabled = false;


        }

    }

    public void Actions()
    {

        if (isOpen == false)
        {
            isOpen = true;
        }

        else if (isOpen == true)
        {
            isOpen = false;
        }
    }


}
