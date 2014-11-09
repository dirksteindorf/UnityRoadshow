﻿using UnityEngine;
using System.Collections;

public class ScoreManager : Singleton<ScoreManager>
{
	public GUIText scoreGUIText;
	public GUIText highScoreGUIText;

	private int score;
	private int highScore;
    private int goodBananaStreak;

    public int Score
    {
        get{ return score;}
    }

    //--------------------------------------------------------------------------
	// Use this for initialization
	void Start () 
    {
        score = 0;
		highScore = 0;
        goodBananaStreak = 0;
	}

    //--------------------------------------------------------------------------
    public void addGoodBanana()
    {
        score += 10;
        goodBananaStreak++;
        checkStreak();
    }

    //--------------------------------------------------------------------------
    void checkStreak()
    {
        // bonus points after a streak of 10 bananas
        if (goodBananaStreak % 10 == 0 && goodBananaStreak > 0)
        {
            // bonus points
            score += 300;
        }
    }

    //--------------------------------------------------------------------------
    public void addBadBanana()
    {
        if (score < 5)
        {
            score = 0;
        } 
        else
        {
            score -= 5;
        }

        goodBananaStreak = 0;
    }
	
    //--------------------------------------------------------------------------
	// Update is called once per frame
	void Update () 
    {
		if (highScore < score)
			highScore = score;

		scoreGUIText.text = "Score: " + score.ToString();
		highScoreGUIText.text = "HighScore: " + highScore.ToString();
	}
}
