using UnityEngine;
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

	private string highScoreKey = "highScore";

    //--------------------------------------------------------------------------
	// Use this for initialization
	void Start () 
    {
        initializeScoreValues();
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

		highScore = PlayerPrefs.GetInt(highScoreKey, 0);
	}

	void initializeScoreValues ()
	{
		score = 0;
		highScore = PlayerPrefs.GetInt(highScoreKey, 0);
	}

	public void Save()
	{
		// save the high score
		PlayerPrefs.SetInt(highScoreKey, highScore);
		PlayerPrefs.Save();
		
		// return to the original game state
		initializeScoreValues();
	}
}
