using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyCloud : MonoBehaviour {
	public float v;
	public float a = 0.015f;
	static public float BeSmallSpeed = 0.02f;
	private float SaveTime, BlackTime;
	bool IsBlack = false, IsSave = false;     //IsSave:Is in save condition
	public Slider WhiteHealth;
	public Slider BlackHealth; 
	public Slider BlackTimeSlider;
	public GameObject camera;
	public GameObject SmileCloud, WhiteCloud, BlackCloud, CryCloud;
	public GameObject BlueSky, BlackSky;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Recover
		if (Time.realtimeSinceStartup - BlackTime >= 10) {
			IsBlack = false;
			BlackHealth.value = WhiteHealth.value;
			transform.localScale = new Vector3 (WhiteHealth.value * 50 + 20, WhiteHealth.value * 50 + 20, WhiteHealth.value * 50 + 20);
		}
		if (Time.realtimeSinceStartup - SaveTime >= 1) 
		{
			IsSave = false;
			var c = BlackCloud.GetComponent<SpriteRenderer> ().color;
			c.a = 1f;
			BlackCloud.GetComponent<SpriteRenderer> ().color = c;
			CryCloud.SetActive (false);
		}

		//State
		if (IsBlack == true) {		//Black
			//ChangeMusic
			camera.GetComponent<AudioSource> ().Pause ();
			if(GetComponent<AudioSource>().isPlaying == false)
				GetComponent<AudioSource>().Play();
			//ChangeState
			BlackCloud.SetActive (true);
			BlackSky.SetActive (true);
			BlueSky.SetActive (false);
			BlackTimeSlider.gameObject.SetActive (true);
			BlackTimeSlider.value = 1 - (Time.realtimeSinceStartup - BlackTime) / 10f;
			CryCloud.SetActive (false);
			SmileCloud.SetActive (false);
			WhiteCloud.SetActive (false);
			BeSmall ();
		} 
		else if(IsBlack == false && CryCloud.active == false){		//White
			GetComponent<AudioSource>().Stop();
			if(camera.GetComponent<AudioSource> ().isPlaying == false)
				camera.GetComponent<AudioSource> ().Play();
			BlackCloud.SetActive (false);
			BlueSky.SetActive (true);
			BlackSky.SetActive (false);
			BlackTimeSlider.gameObject.SetActive (false);
			if (transform.localScale.x >= 50) {
				SmileCloud.SetActive (true);
				WhiteCloud.SetActive (false);
			} 
			else {
				WhiteCloud.SetActive (true);
				SmileCloud.SetActive (false);
			}
		}
			
		
		//Jump
		Jump();

		//IsOver?
		if (WhiteHealth.value <= 0)
			PlayStation.IsOver = true;
			
	}

	void Jump(){
		if (Input.GetAxis ("Jump") != 0 || Input.touchCount > 0) {
			v = -0.1f;
			if (transform.position.y <= 33f) {
				transform.position += new Vector3 (0, 0.8f, 0);
			} 
			else {
				transform.position += new Vector3 (0, 0, 0);
			}
		} 
		else {
			v -= a;
			if (transform.position.y >= -31f) {
				transform.position += new Vector3 (0, v, 0);
			} 
			else {
				transform.position += new Vector3 (0, 0, 0);
			}
		}
	}
	public void Init(){
		v = 0;
		IsBlack = false;
		IsSave = false;
		WhiteHealth.value = 0.2f;
		BlackHealth.value = 0.2f;
		transform.localScale = new Vector3 (30, 30, 30);
		transform.localPosition = new Vector3(-551, 0, -252);
	}


	void BeSmall(){
		
		transform.localScale -= new Vector3 (BeSmallSpeed, BeSmallSpeed, BeSmallSpeed);
		if (BlackHealth.value <= WhiteHealth.value) {
			BlackHealth.value -= BeSmallSpeed / 50f;
			WhiteHealth.value -= BeSmallSpeed / 50f;
		}
		else
			BlackHealth.value -= BeSmallSpeed / 50f;
	}

	//Trigger
	void OnTriggerEnter2D(Collider2D other){
		//GetWhiteCloud
		if (other.gameObject.tag == "WhiteCloud") {
			Score.score++;
			if (transform.localScale.x < 70) 
			{
				transform.localScale += new Vector3 (1f, 1f, 1f);
				WhiteHealth.value += 0.02f;
				if (BlackHealth.value <= WhiteHealth.value)
					BlackHealth.value = WhiteHealth.value;
				else
					BlackHealth.value += 0.02f;
			}
		} 
		//GetBlackCloud
		else if (other.gameObject.tag == "BlackCloud")
		{
			if(IsBlack == false)
				BlackTime = Time.realtimeSinceStartup;
			IsBlack = true;
			if (transform.localScale.x < 70)
			{
				transform.localScale += new Vector3 (0.5f, 0.5f, 0.5f);
				BlackHealth.value += 0.01f;
			}
		} 
		//GetPlane
		else if (other.gameObject.tag == "Plane" && IsSave == false)
		{
			IsSave = true;
			SaveTime = Time.realtimeSinceStartup;
			if (IsBlack == false) {
				CryCloud.SetActive (true);
				WhiteCloud.SetActive (false);
				SmileCloud.SetActive (false);
			} 
			var c = BlackCloud.GetComponent<SpriteRenderer> ().color;
			c.a = 0.5f;
			BlackCloud.GetComponent<SpriteRenderer> ().color = c;

			transform.localScale -= new Vector3 (5f, 5f, 5f);
			if (BlackHealth.value - WhiteHealth.value >= 0.1f)
				BlackHealth.value -= 0.1f;
			else
			{
				WhiteHealth.value -= (0.1f - (BlackHealth.value - WhiteHealth.value)); 
				BlackHealth.value = WhiteHealth.value;
			}
		}
	}
		
		
}
	
