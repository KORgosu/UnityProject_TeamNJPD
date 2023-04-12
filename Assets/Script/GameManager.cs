using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("# Game Control")]
    public bool isLive;
    [Header("# Player Info")]
    public float health;
    public float maxHealth = 100;
    public int level;
    public int[] nextExp = { 3, 5, 10, 150, 210, 280, 360, 450, 600};
    public int kill;
    public int exp;
    [Header("# Game Object")]
    public Player player;
    public PoolManager pool;
    
    


    public float gameTime; //게임시간
    public float maxGameTime = 2 * 10f; // <-- 최대 게임시간 (현재 20초)

    void Awake()
    {
        instance = this; // 초기화
    }

    void Start() {
        health = maxHealth;
    }
    public void GetExp() // 경험치증가함수
    {
        exp++;

        if (exp == nextExp[level])  {
            level++;
            exp = 0;
        }
    }

    void Update() 
    {
        if(!isLive)
           return;

        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime) {
            gameTime = maxGameTime;
        }
    }

    public void Stop() //멈추기
    {
        isLive = false;
        Time.timeScale = 0;      //유니티의 시간 속도, 0이면 멈춤

    }

    public void Resume() //게임 재개
    {
        isLive = true;
        Time.timeScale = 1;

    }


}
