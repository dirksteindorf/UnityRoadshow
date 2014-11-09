using UnityEngine;
using System.Collections;

public class BananaRise : MonoBehaviour {
	
	public	float	speed		= 0;
	public	float	waitInit	= 0;
	public	float	waitMid		= 0;
	public	float	waitLast	= 0;
	public	float	direction	= 0;

	private	float	count		= 0;
	private	float	waitTimer	= 0;
	private	bool	texChng		= true;

	Vector3 endpos ;
	Vector3 startpos ;

//	public bool LerpOut=false;
//	public bool LerpIn=false;
	

	// Use this for initialization
	void Start () {
	
		endpos		= this.transform.position + new Vector3(0, 1.5f, 0);
		startpos	= this.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if (LerpIn) {
//			LerpIn=false;
//			direction=-1;
//				}
//		if (LerpOut) {
//			LerpOut=false;
//			direction=1;
//		}

		if (direction <= 0 && this.rigidbody2D.transform.position == startpos)
		{
			direction = 0;
			if( (waitTimer += Time.deltaTime) >= waitInit )
			{
				waitTimer = 0;
				direction = 1;
				texChng = true;
			}
		} 
		else if (this.rigidbody2D.transform.position == endpos)
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
				texChng = false;
			}


		}

		count += Time.deltaTime * speed * direction;
		count = Mathf.Max (0, Mathf.Min (1, count));
		//Debug.Log (count);
		//Debug.Log (direction);

		this.rigidbody2D.transform.position = Vector2.Lerp (startpos, endpos, count);

//		Debug.Log (waitTimer);
	
	}
}