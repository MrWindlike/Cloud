using UnityEngine;
using System.Collections;

public class UpAndDown : MonoBehaviour {
	float s = 0;
	float speed = 0.05f;
	bool IsUp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (s <= -2f)
			IsUp = true;
		else if (s >= 0f)
			IsUp = false;

		if (IsUp == true) {
			transform.position += new Vector3 (0, speed, 0);
			s += speed;
		} 
		else {
			transform.position -= new Vector3 (0, speed, 0);
			s -= speed;
		}
	}
}
