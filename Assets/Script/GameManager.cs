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
    public float maxGameTime = 2 * 10f;
    [Header("# Player Info")]
    public int playerId;
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
    public LevelUp uiLevelUp;
    public GameObject enemyCleaner;

    void Awake()
    {
        instance = this; // 초기화
    }

    public void GameStart(int id) {
        playerId = id;
        health = maxHealth;

        player.gameObject.SetActive(true); //플레이어 활성화
        uiLevelUp.Select(playerId % 2); // 무기 지급
        Resume(); //재개
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
        if (!isLive)
            return;
            
        exp++;

        if (exp == nextExp[Mathf.Min(level, nextExp.Length-1)])  {
            level++;
            exp = 0;
            uiLevelUp.Show();
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
