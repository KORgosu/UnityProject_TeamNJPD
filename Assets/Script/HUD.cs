using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour//Head Up Display
{
    public enum InfoType { Exp, Level, Kill, Time, Health }  //UI창에 나타 낼 변수들 각각 "경험치, 레벨, 죽인 수, 시간 ,체력"
    public InfoType type;

    Text myText;
    Slider mySlider;

    void Awake() 
    {    
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
        
    }

    private void LateUpdate()  //GameManager 스크립트에 있는 자료를 가져오는 함수
    {
        switch (type) {          
            case InfoType.Exp:
                float curExp = GameManager.instance.exp;
                float maxExp = GameManager.instance.nextExp[Mathf.Min(GameManager.instance.level, GameManager.instance.nextExp.Length - 1)];
                mySlider.value = curExp / maxExp;

                break;
            case InfoType.Health:
                float curHealth = GameManager.instance.health;
                float maxHealth = GameManager.instance.maxHealth;
                mySlider.value = curHealth / maxHealth;

                break;
            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", GameManager.instance.kill);

                break;
            case InfoType.Level:
                myText.text = string.Format("Lv.{0:F0}", GameManager.instance.level);

                break;
            case InfoType.Time:
                float reaminTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
                int min = Mathf.FloorToInt(reaminTime / 60);
                int sec = Mathf.FloorToInt(reaminTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}" , min, sec);
                break; 
                
        }
        
    }





}
