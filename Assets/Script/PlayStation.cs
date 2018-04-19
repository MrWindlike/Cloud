using UnityEngine;
using System.Collections;

public class PlayStation : MonoBehaviour {
	public GameObject BeginState;
	public GameObject EndState;
	public GameObject whiteCloud;
	public GameObject blackCloud;
	public GameObject plane;
	private int buildnum;
	static public bool IsOver;
	private int WHITECLOUD, BLACKCLOUD, PLANE = 100, MAXNUM;
	static public float PlayTime;
	// Use this for initialization

	void Start () {
		Debug.Log (Time.realtimeSinceStartup);
	}

	// Update is called once per frame
	void Update () {
		//Improve Level
		if (Time.realtimeSinceStartup - PlayTime < 5) {
			WHITECLOUD = 50;
			BLACKCLOUD = 90;
			MAXNUM = 10;
			MyCloud.BeSmallSpeed = 0.02f;
		} 
		else if (Time.realtimeSinceStartup - PlayTime >= 5 && Time.realtimeSinceStartup - PlayTime < 15) {
			WHITECLOUD = 50;
			BLACKCLOUD = 80;
			MyCloud.BeSmallSpeed = 0.025f;
		} 
		else if (Time.realtimeSinceStartup - PlayTime >= 15 && Time.realtimeSinceStartup - PlayTime < 50) {
			WHITECLOUD = 40;
			BLACKCLOUD = 80;
			MyCloud.BeSmallSpeed = 0.04f;
			MAXNUM = 11;
		} 
		else if (Time.realtimeSinceStartup - PlayTime >= 50) {
			WHITECLOUD = 35;
			BLACKCLOUD = 80;
			MyCloud.BeSmallSpeed = 0.04f;
			MAXNUM = 11;
		}
		//Build
		if (Float.count  + Fly.PlaneNum < MAXNUM) 
		{
			buildnum = Random.Range (0, 100);
			if (buildnum < WHITECLOUD) {
				Instantiate (whiteCloud);
				Float.WhiteNum++;
				Float.count++;
			} 
			else if (buildnum < BLACKCLOUD) {
				Instantiate (blackCloud);
				Float.BlackNum++;
				Float.count++;
			} 
			else if (buildnum < PLANE &&  Fly.PlaneNum < 5) {
				Instantiate (plane);
				Fly.PlaneNum++;
			}
		}

		//GameOver
		if (IsOver)
		{
			rain.IsDetroied = true;
			EndState.SetActive (true);
			gameObject.SetActive (false);
		}
			
	}


	public void OnClickBackButton(){
		rain.IsDetroied = true;
		BeginState.SetActive (true);
		gameObject.SetActive (false);
	}

}
