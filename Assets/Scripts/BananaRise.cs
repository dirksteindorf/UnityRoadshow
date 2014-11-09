using UnityEngine;
using System.Collections;

public class BananaRise : MonoBehaviour {
	
	public	float	speed		= 0;
//	public	float	normSpeed	= 0;
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
	private bool	texChng		= false;

	Vector2 endpos;
	Vector2 startpos;
	Vector2 actPos;

    public bool canMove = false;
    public int x;
    public int y;

	public ParticleSystem sleepHit;
	public ParticleSystem laughHit;


//	public bool LerpOut=false;
//	public bool LerpIn=false;
	

	// Use this for initialization
	void Start () {
	
		startpos	= new Vector2 (this.transform.position.x, this.transform.position.y);
		endpos		= startpos + new Vector2(0, .8f);
		actPos		= startpos;
//		normSpeed 	= speed;
        direction = 1;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (canMove)
        {
			texChng = lol;
            Update2();
        } 
        else
        {
            //this.transform.position.x = startpos.x;
            //this.transform.position.y = startpos.y;
            this.rigidbody2D.transform.position = startpos;
			count = 0;
        }
    }

	void Update2 ()
	{
		// Determine current Position
		actPos = new Vector2 (this.transform.position.x, this.transform.position.y);

		// Wait in the Ground
		if (direction <= 0 && actPos == startpos)
		{
            canMove = false;
            GameManager.instance.occupationGrid[x,y] = 0;
			GameManager.instance.freeSlots++;
			//if( (waitTimer += Time.deltaTime) >= waitInit )
			//{
			//speed = normSpeed;
			//waitTimer = 0;
			direction = 1;
			this.GetComponent<SpriteRenderer> ().sprite = oldFace;
            return;
			//}
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
				this.GetComponent<SpriteRenderer> ().sprite = newFace;
				texChng = false;
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
//			speed		= 5;
//			direction	= -1;
			waitTimer	= 0;

			// Change Sprite
			if(	lol )
            {
				this.GetComponent<SpriteRenderer> ().sprite = newFace;
				ScoreManager.instance.addGoodBanana();
				SpecialEffects.instance.create(laughHit, transform.position);
				lol = false;
            }
            else
            {
                ScoreManager.instance.addBadBanana();
				SpecialEffects.instance.create(sleepHit, transform.position);
            }
            this.canMove = false;
			GameManager.instance.freeSlots++;
			GameManager.instance.occupationGrid[this.x, this.y] = 0;

		}


	}





}