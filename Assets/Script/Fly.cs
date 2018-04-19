using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {
	public float v;
	public float a;
	static public int PlaneNum = 0;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (82.5f, Random.Range (33, -31), -26.8361f);
		v = Random.Range (1f, 1.5f);
	}
	// Update is called once per frame
	void Update () {
		v += a;
		transform.position -= new Vector3 (v, 0, 0);
		if (transform.position.x <= -90f) 
		{
			Destroy (gameObject);
			PlaneNum--;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == "Destroy") 
		{
			Destroy (gameObject);
			PlaneNum--;
		}
	}
}
