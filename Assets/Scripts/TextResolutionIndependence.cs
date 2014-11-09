using UnityEngine;
using System.Collections;

public class TextResolutionIndependence : MonoBehaviour
{
	public Vector2 scaleOnRatio = new Vector2(0.1f, 0.2f);
	private Transform myTrans;
	private float widthHeightRatio;

	// Use this for initialization
	void Start()
	{
		myTrans = this.transform;
		setScale();
	}

	void setScale()
	{
		widthHeightRatio = (float)Screen.width / Screen.height;
		myTrans.localScale = new Vector3(scaleOnRatio.x, widthHeightRatio * scaleOnRatio.y, 1);
	}
}
