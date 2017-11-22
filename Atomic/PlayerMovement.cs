using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float Speed = 20;

    public float RotateSpeed;

    private string TurnAxisName;
    private Rigidbody RB;
    private float TurnInputValue;

    private string RotationAxisName;
    private float RotateInputValue;

    private int ForceValue = 1000;

    public float Timer;
    public int count;


    public Transform GasGauge;
    public Text Indicator;
    [SerializeField]
    public float CurrentAmount;
    [SerializeField]
    public float Timerspeed;

    public float TurnTimer = 1;



    void Awake()
    {
        RB = GetComponent<Rigidbody>();
        CurrentAmount = 100;
        Timer = 0;
        count = 0;
        TurnTimer = 1;
    
    }

    void Start() {
        TurnAxisName = "Horizontal";

  
    }

    void Update() {

        Timer += Time.deltaTime;
        if(Timer >= 5)
        {
            Speed += 2;
            Timer = 0;
        }
        TurnTimer -= Time.deltaTime;
        if(TurnTimer <= 0)
        {
            TurnTimer = 0;
        }
      
        if(CurrentAmount >= 100)
        {
            CurrentAmount = 100;
        }
        


        CurrentAmount -= Timerspeed * Time.deltaTime;

        if (CurrentAmount < 0)
        {
            CurrentAmount = 0;
        }

        TurnInputValue = Input.GetAxis(TurnAxisName);
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        SetEnergyUI();

         if (Input.GetKey(KeyCode.Q))
         {
            transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);
        }
         if (Input.GetKey(KeyCode.D))
         {
            transform.Rotate(-Vector3.forward * RotateSpeed * Time.deltaTime);
        }

  if (CurrentAmount <= 0)
        {
            CurrentAmount = 0;
        }

        if (CurrentAmount == 0)
        {
            SceneManager.LoadScene("defaite");
        }
    }


    private void FixedUpdate()
    {

        RB.AddForce(-Vector3.up * ForceValue);

    }
    
    IEnumerator Rotate(Vector3 axis, float angle, float duration = 1.0f)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;
    }





   void OnTriggerEnter(Collider coll)
    {

     
        if (coll.gameObject.tag == "Photon")
        {
            CurrentAmount += 5;
            count++;
            coll.gameObject.SetActive(false);

        }    

        if(coll.gameObject.tag == "House")
        {
            SceneManager.LoadScene("victoire");
        }

        if (coll.gameObject.tag == "TurnLeft" && TurnTimer ==0)
        {
            StartCoroutine(Rotate(Vector3.up, -90f, 1f));

            //transform.Rotate(0, -90, 0);
            TurnTimer = 1;
        }
        if (coll.gameObject.tag == "TurnRight" && TurnTimer == 0)
        {
            StartCoroutine(Rotate(Vector3.up, 90f, 1f));
            //transform.Rotate(0, 90, 0);
            TurnTimer = 1;
        }

    }


        
    void SetEnergyUI()
    {
        Indicator.GetComponent<Text>().text = ((int)CurrentAmount).ToString() + "%";
        GasGauge.GetComponent<Image>().fillAmount = CurrentAmount / 100;

    }


    void OnTriggerStay(Collider coll)
    {

      





        if (coll.gameObject.tag == "Wood")
        {

            CurrentAmount -= Timerspeed * Time.deltaTime * 2;
            SetEnergyUI();
        }

         if (coll.gameObject.tag == "Copper")
            {
                Speed = Speed * 2 *Time.deltaTime;
            }

       
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Wood")
        {
            CurrentAmount -= Timerspeed * Time.deltaTime;
        }
    }
}







