using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
	public GUIText timerGUIText;
	private float time;

	// Use this for initialization
	void Start ()
	{
		time = 180;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// decrease timer and convert it in the right format
		time -= Time.deltaTime;
		System.TimeSpan t = System.TimeSpan.FromSeconds(time);

		if (time <= 0)
		{
			time = 0;
			//TODO Game Over
		}

		// display remaining time
		timerGUIText.text = string.Format("{0:0}:{1:00}", t.Minutes, t.Seconds);
	}
}
