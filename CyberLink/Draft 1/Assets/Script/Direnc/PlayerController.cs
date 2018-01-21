using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    /*   public float moveSpeed;
       private Rigidbody rigid;


       void Start()
       {
           rigid = GetComponent<Rigidbody>();
       }

       void Update()
       {
           float Horizontal = Input.GetAxis("Horizontal");
           float Vertical = Input.GetAxis("Vertical");

           Vector3 move = new Vector3(Horizontal, 0, Vertical)* moveSpeed * Time.deltaTime;
           rigid.MovePosition(transform.position + move);

       }*/
    public float moveSpeed;
    private string m_MovementAxisName;
    private Rigidbody rigid;
    private float m_MovementInputValue;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        m_MovementInputValue = 0f;
    }

    void Start()
    {
        m_MovementAxisName = "Vertical";
    }

    void Update()
    {
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
    }
    void FixedUpdate()
    {
         Move();
    }

    void Move()
    {
        Vector3 movement = transform.forward * m_MovementInputValue * moveSpeed * Time.deltaTime;
        rigid.MovePosition(rigid.position + movement);
    }






}