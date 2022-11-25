using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventHelper : MonoBehaviour
{
    public delegate void AddScore(int score);
    public static AddScore OnAddScore;
    public delegate void GameOver();
    public static GameOver OnGameOver;
    public delegate void GameStart();
    public static GameStart OnGameStart;
}
