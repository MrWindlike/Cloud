using UnityEngine;
using System.Collections;

public class rain : MonoBehaviour {
	static public float OriginX, OriginY, OriginZ;
	static public int MaxNum = 100, Num = 0;
	static public bool IsDetroied = false;
	float v;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (OriginX + Random.Range (-4, 5), OriginY - 3, OriginZ);
		v = Random.Range (1, 2);
		Num++;
	}

	// Update is called once per frame
	void Update () {
		transform.position -= new Vector3 (0, v, 0);

		if (transform.position.y <= -50 || IsDetroied == true) {
			Destroy (gameObject);
			Num--;
		}
	}
}
