using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public PoolManager pool;


    public float gameTime; //게임시간
    public float maxGameTime = 2 * 10f; // <-- 최대 게임시간 (현재 20초)

    void Awake()
    {
        instance = this; // 초기화
    }

}
