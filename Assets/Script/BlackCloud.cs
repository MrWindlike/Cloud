using UnityEngine;
using System.Collections;

public class BlackCloud : MonoBehaviour {
	public GameObject Rain;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//rain
		if (rain.MaxNum >= rain.Num) {
			rain.OriginX = transform.position.x;
			rain.OriginY = transform.position.y;
			rain.OriginZ = transform.position.z;
			Instantiate (Rain);
		}
	}
}
