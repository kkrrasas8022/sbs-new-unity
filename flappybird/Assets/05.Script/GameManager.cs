using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    //필요한것
    //플레이어 객체
    //스코어 저장 변수
    [SerializeField]public Player player;
    public int ScoreNum;
    [SerializeField] private GameObject gameOver;
    [SerializeField] List<MoveGround> grounds; 
    public Action OnScoreUp;
    public Action OnGameOver;
    public Action OnRestart;

    private void Start()
    {
        if(gameOver.activeSelf==true)
        {
            gameOver.SetActive(false);
        }
        OnScoreUp += () =>
        {
            ScoreNum++;
        };
        OnGameOver += GameOver;
        OnRestart += Restart;
    }
    
    private void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    private void Restart()
    {
        gameOver.SetActive(false);
        Time.timeScale = 1;
        ScoreNum = 0;
        player.Start();
        float i = 0;
        foreach(var item in grounds)
        {
            item.gameObject.SetActive(false);
            item.gameObject.SetActive(true);
            item.transform.position = new Vector3(i, 0, 0);
            i = i + 6.4f;
        }
    }

    private static GameManager _instance = null;
    private void Awake()
    {
        if(_instance == null )
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                return null;
            }
            return _instance;
        }
    }
}
