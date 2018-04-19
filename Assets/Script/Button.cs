using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	bool IsBeSmall;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale.x >= 1.2f)
			IsBeSmall = true;
		else if (transform.localScale.x <= 1f)
			IsBeSmall = false;

		if(IsBeSmall == false)
			transform.localScale += new Vector3 (0.01f, 0.01f, 0.01f);
		else
			transform.localScale -= new Vector3 (0.01f, 0.01f, 0.01f);
	}
}
