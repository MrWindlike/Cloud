using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndStation : MonoBehaviour {
	public GameObject BeginState;
	public GameObject camera;
	public GameObject BlackCloud, WhiteCloud, SmileCloud;
	public Text text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rain.IsDetroied = false;
		text.text = " " + Score.score;
		if (Input.GetMouseButton (0)) {
			rain.IsDetroied = true;
			BeginState.SetActive (true);
			gameObject.SetActive (false);
		}

		if (Score.score <= 20) {
			BlackCloud.SetActive (true);
			WhiteCloud.SetActive (false);
			SmileCloud.SetActive (false);
		} 
		else if (Score.score > 20 && Score.score <= 60) {
			BlackCloud.SetActive (false);
			WhiteCloud.SetActive (true);
			SmileCloud.SetActive (false);
		} 
		else if (Score.score > 60) {
			BlackCloud.SetActive (false);
			WhiteCloud.SetActive (false);
			SmileCloud.SetActive (true);
		}
			
	}
}
