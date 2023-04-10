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
    public void GetExp()
    {
        exp++;

        if (exp == nextExp[level])  {
            level++;
            exp = 0;
        }
    }

}
