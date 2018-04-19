using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Loading : MonoBehaviour {
	float alpha = 0.01f, RenderTime;
	public GameObject BeginState, LoadingState;
	// Use this for initialization
	void Start () {
		RenderTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (alpha);
		var c = gameObject.GetComponent<RawImage> ().color;
		c.a = alpha;
		gameObject.GetComponent<RawImage> ().color = c;
		if (Time.realtimeSinceStartup - RenderTime < 2f)
			alpha += 0.01f;
		else
			alpha -= 0.01f;

		if (alpha <= 0) {
			BeginState.SetActive (true);
			LoadingState.SetActive (false);
		}
	}
}
