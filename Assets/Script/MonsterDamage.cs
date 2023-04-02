using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public float damage;
    public PlayerHealth PlayerHealth;

void OnCollisionEnter2D(Collision2D collision) //2D물체와 충돌시 발생하는 함수
{
    if(collision.gameObject.tag == "Player") //플레이어 태그를 가진 물체와 부딪힐 시
    {
        PlayerHealth.TakeDamage(damage); //데미지 입음 (PlayerHealth.cs 에 있는 TakeDamage 함수 참조)
    }
}
}
