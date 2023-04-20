using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("# Game Control")]
    public bool isLive;
    public float gameTime;
    public float maxGameTime = 3 * 10f;
    [Header("# Player Info")]
    public int PlayerId;
    public float health;
    public float maxHealth = 100;
    public int level;
    public int[] nextExp = { 3, 5, 10, 150, 210, 280, 360, 450, 600};
    public int kill;
    public int exp;
    [Header("# Game Object")]
    public Player player;
    public PoolManager pool;
    public Result uiResult;
    public GameObject enemyCleaner;



    void Awake()
    {
        instance = this; // 초기화
  
    }


    public void GameStart(int id) {
        PlayerId = id;
        health = maxHealth;
        
        Resume();
        
    }

    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        isLive = false;

        yield return new WaitForSeconds(0.5f);

        uiResult.gameObject.SetActive(true);
        uiResult.Lose();
        Stop();
    }


    public void GameVictory()
    {
        StartCoroutine(GameVictoryRoutine());
    }

    IEnumerator GameVictoryRoutine()
    {
        isLive = false;
        enemyCleaner.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        uiResult.gameObject.SetActive(true);
        uiResult.Win();
        Stop();
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }



    public void GetExp() // 경험치증가함수
    {
        if (!isLive) //게임 승리시 몬스터 전부 죽게 설정했는데 그 때 경험치 먹는거 막아주는 조건문
            return;

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
            GameVictory();
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
