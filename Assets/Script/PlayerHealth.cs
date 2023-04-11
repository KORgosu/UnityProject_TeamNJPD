using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 10;  //최대체력
    public float health; //현재체력

    void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(float damage) // 데미지 받는 함수
    {
        health -= damage; 
        if(health <=0) //플레이어 체력이 0이하가 될 시 사망
        {
            Destroy(gameObject);
        }

    }


}
