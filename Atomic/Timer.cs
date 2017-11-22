using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {


    public Transform GasGauge;
    public Text Indicator;

    [SerializeField]
    public float CurrentAmount;
    [SerializeField]
    public float speed;

    void Start()
    {
        CurrentAmount = 100;
    }

    void Update()
    {
        if (CurrentAmount <= 100)
        {
            CurrentAmount -= speed * Time.deltaTime;
        }

        GasGauge.GetComponent<Image>().fillAmount = CurrentAmount / 100;


        if (CurrentAmount < 0)
        {
            CurrentAmount = 0;

        }
    }
}
