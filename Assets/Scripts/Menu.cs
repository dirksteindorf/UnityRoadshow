using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
	private bool mainMenu = true;

	void OnGUI()
	{
		if (mainMenu == true)
		{
			if (GUI.Button(new Rect(240, 100, 100, 25), "Start"))
			{
				Application.LoadLevel(1);
			}
			else if (GUI.Button(new Rect(240, 220, 100, 25), "Quit"))
			{
				Application.Quit();
			}
			else if (GUI.Button(new Rect(240, 160, 100, 25), "Credits"))
			{
				mainMenu = false;
			}
		}
		else
		{
			GUI.Label(new Rect(240, 100, 150, 25), "Aleksandar Stojnic");
			GUI.Label(new Rect(240, 160, 100, 25), "Sven Schönfeld");
			GUI.Label(new Rect(240, 220, 100, 25), "Dirk Steindorf");

			if (GUI.Button(new Rect(220, 250, 150, 25), "Return to Main Menu"))
				mainMenu = true;
		}
	}
}
