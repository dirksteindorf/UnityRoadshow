using UnityEngine;
using System.Collections;

public class mouseClick : MonoBehaviour {

    void OnMouseDown()
    {
        Debug.Log("Clicked me");
        Debug.Log(this.gameObject.GetComponent<test>().narf);
    }
}
