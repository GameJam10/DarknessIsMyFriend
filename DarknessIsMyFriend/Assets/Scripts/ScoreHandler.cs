using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private static int live = 3;
    private static int score = 0;
    private static int pointsToAdd = 0;

    [SerializeField] int points = 0;

    private void Awake()
    {
        pointsToAdd = points;
    }

    public static int getLive()
    {
        return live;
    }

    public static void hit()
    {
        live -= 1;
        Debug.Log(live);
    }

    public static int getScore()
    {
        return score;
    }

    public static void addScore()
    {
        score += pointsToAdd;
        Debug.Log(score);
    }

    private static void Update()
    {
        if (live == 0)
        {
            Debug.Log("Game Over");
        }
    }
}
