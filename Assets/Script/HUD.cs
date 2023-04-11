using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp, Level, Kill, Time, Health }
    public InfoType type;

    Text myText;
    Slider mySlider;

    void Awake() 
    {    
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
        
    }

    private void LateUpdate() 
    {
        switch (type) {          
            case InfoType.Exp:
            float curExp = GameManager.instance.exp;
            float maxExp = GameManager.instance.nextExp[GameManager.instance.level];
            mySlider.value = curExp / maxExp;

                break;
            case InfoType.Health:
                float curHealth = GameManager.instance.health;
                float maxHealth = GameManager.instance.maxHealth;
                mySlider.value = curHealth / maxHealth;

                break;
            case InfoType.Kill:

                break;
            case InfoType.Level:

                break;
            case InfoType.Time:

                break; 
                
        }
        
    }





}