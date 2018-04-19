using UnityEngine;
using System.Collections;

public class AboutStation : MonoBehaviour {
	public GameObject BeginState;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) == true) {
			BeginState.SetActive (true);
			gameObject.SetActive (false);
		}
	}
}
