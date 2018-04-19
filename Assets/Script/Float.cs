using UnityEngine;
using System.Collections;

public class Float : MonoBehaviour {
	static public int count = 0;
	static public int WhiteNum = 0, BlackNum = 0;
	private float v;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (82.5f, Random.Range (33, -31), -26.8361f);
		v = Random.Range (0.9f, 1.8f);
	}

	// Update is called once per frame
	void Update () {
		transform.position -= new Vector3 (v, 0.1f);
	}

	void OnTriggerEnter2D(Collider2D other){
		count--;
		if (gameObject.tag == "WhiteCloud")
			WhiteNum--;
		else
			BlackNum--;
		Destroy (gameObject);
	}
		

}
