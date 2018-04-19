using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GameObject PlayState;
	public GameObject EndState;
	public GameObject Rule;
	public GameObject AboutState;
	public GameObject camera;
	public MyCloud cloud;
	void Awake(){
		PlayState.SetActive (false);
		EndState.SetActive (false);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (camera.GetComponent<AudioSource> ().isPlaying == false) {
			Debug.Log ("Play");
			camera.GetComponent<AudioSource> ().Play ();
		}
	}

	public void OnClickPlayButton(){
		rain.IsDetroied = false;
		cloud.Init ();
		PlayStation.PlayTime = Time.realtimeSinceStartup;
		Debug.Log (Time.realtimeSinceStartup);
		Score.score = 0;
		PlayStation.IsOver = false;
		PlayState.SetActive (true);
		gameObject.SetActive (false);

	}
	public void OnClickRuleButton(){
		Rule.SetActive (true);
		gameObject.SetActive (false);
	}

	public void OnClickAboutButton(){
		AboutState.SetActive (true);
		gameObject.SetActive (false);
	}
	public void OnClickExitButton(){
		Application.Quit ();
	}
}
