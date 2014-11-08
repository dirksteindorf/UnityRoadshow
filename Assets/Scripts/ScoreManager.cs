using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
    private int score;
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
        goodBananaStreak = 0;
	}

    //--------------------------------------------------------------------------
    void addGoodBanana()
    {
        score += 10;
        goodBananaStreak++;
        checkStreak();
    }

    //--------------------------------------------------------------------------
    void checkStreak()
    {
        if (goodBananaStreak == 10)
        {
            // TODO: add bonus
        }
        // TODO: bigger streak with bigger bonus?
    }

    //--------------------------------------------------------------------------
    void addBadBanana()
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
	    // TODO: draw score
	}
}
