using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Points;
    public string LevelName;
    public BallControllerPooler BallPooler;
    
    public UnityAction OnBallEnteredBox;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("There is already a GameManger instance!");
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        Points += points;
        
        Debug.Log("On Ball Enter!");
        OnBallEnteredBox.Invoke();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(LevelName);
    }
    
}
