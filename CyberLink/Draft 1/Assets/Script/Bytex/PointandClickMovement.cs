using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PointandClickMovement : MonoBehaviour {

    private NavMeshAgent mNavMeshAgent;
    public bool mRunning = false;


	void Start () {
        mNavMeshAgent = GetComponent<NavMeshAgent>();
        mRunning = false;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                mNavMeshAgent.destination = hit.point;
          
            }
        }

        if(mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
        {
            mRunning = false;
        }
        else
        {
            mRunning = true;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Computer"))
        {
            Debug.Log("Time to leave");
        }
    }

}
