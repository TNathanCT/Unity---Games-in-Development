using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHP : MonoBehaviour {

    public int StartingHealth = 100;
    public Slider HPSlider;
    public Image mFillImage;
    public Color FullHPColor = Color.green;
    public Color ZeroHPColor = Color.red;
    private int CurrentHP;
    private bool dead;

	
	void OnEnable () {
        CurrentHP = StartingHealth;
        dead = false;
        SetHealthUI();
	}
	
	// Update is called once per frame
	void TakeDamage () {
       // CurrentHP -= amount;
        SetHealthUI();
        if(CurrentHP <= 0f && !dead)
        {
            Death();
        }
		
	}

    void SetHealthUI()
    {
        HPSlider.value = CurrentHP;
        mFillImage.color = Color.Lerp(ZeroHPColor, FullHPColor, CurrentHP / StartingHealth);
    }

    void Death()
    {

    }
}
