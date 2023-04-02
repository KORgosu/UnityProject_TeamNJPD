using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("# Game Object")]//카테고리 이름(헤더),인스펙터의 속성들을 이쁘게 구분시켜주는 타이틀
    public Player player;
    public PoolManager pool;
    [Header("# player Info")]//위와 동일
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 };


    public float gameTime; //게임시간
    public float maxGameTime = 2 * 10f; // <-- 최대 게임시간 (현재 20초)

    void Awake()
    {
        instance = this; // 초기화
    }

    public void GetExp()//경험치 획득 함수
    {
        exp++;

        if(exp == nextExp[level])
        {
            level++;
            exp = 0;
        }
    }
}
