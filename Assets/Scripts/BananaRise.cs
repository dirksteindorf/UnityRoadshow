using UnityEngine;
using System.Collections;

public class BananaRise : MonoBehaviour {
	
	public	float	speed		= 0;
	public	float	normSpeed	= 0;
	public	float	direction	= 0;
	public	float	waitInit	= 0;
	public	float	waitMid		= 0;
	public	float	waitLast	= 0;
	
	public BoxCollider2D Blocker;

	public Sprite	oldFace = null;
	public Sprite	newFace = null;
	public bool		lol		= false;


	private	float	count		= 0;
	private	float	waitTimer	= 0;
	private	bool	texChng		= true;

	Vector2 endpos;
	Vector2 startpos;
	Vector2 actPos;


//	public bool LerpOut=false;
//	public bool LerpIn=false;
	

	// Use this for initialization
	void Start () {
	
		startpos	= new Vector2 (this.transform.position.x, this.transform.position.y);
		endpos		= startpos + new Vector2(0, .5f);
		actPos		= startpos;
		normSpeed 	= speed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Determine current Position
		actPos = new Vector2 (this.transform.position.x, this.transform.position.y);

		// Wait in the Ground
		if (direction <= 0 && actPos == startpos)
		{
			direction = 0;
			if( (waitTimer += Time.deltaTime) >= waitInit )
			{
				speed = normSpeed;
				waitTimer = 0;
				direction = 1;

				if(	lol )
					this.GetComponent<SpriteRenderer> ().sprite = oldFace;
			}
		} 

		// Calculate individual motion steps
		count += Time.deltaTime * speed * direction;
		count = Mathf.Max (0, Mathf.Min (1, count));

		// Move Banana
		this.rigidbody2D.transform.position = Vector2.Lerp (startpos, endpos, count);

		// Determine current Position
		actPos = new Vector2 (this.transform.position.x, this.transform.position.y);

		// Wait Outside
		if (actPos == endpos)
		{
			direction = 0;
			if( (waitTimer += Time.deltaTime) >= (waitMid + waitLast) )
			{
				waitTimer = 0;
				direction = -1;
			}

			if( waitTimer >= waitMid && texChng )
			{
				// Change Sprite
				if(	lol )
					this.GetComponent<SpriteRenderer> ().sprite = newFace;

			}
		}


	
	}

	// Whack the Banana
	void OnMouseDown()
	{
		//if (Blocker.bounds.Contains (Input.mousePosition))
		//	return;

		if (actPos != startpos)
		{
			speed		= 5;
			direction	= -1;
			waitTimer	= 0;

			// Change Sprite
			if(	lol )
            {
				this.GetComponent<SpriteRenderer> ().sprite = newFace;
                Camera.main.GetComponent<ScoreManager>().addGoodBanana();
            }
            else
            {
                Camera.main.GetComponent<ScoreManager>().addBadBanana();
            }
			texChng = false;
		}


	}





}