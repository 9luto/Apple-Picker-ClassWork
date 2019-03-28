using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {


	public Text scoreGT;
	public Text HighScore;

	void Start () {
		GameObject scoreGO = GameObject.Find ("ScoreCounter");
		scoreGT = scoreGO.GetComponent<Text> ();
		scoreGT.text = "0";

		GameObject scoreHI = GameObject.Find ("HighScore");
		HighScore = scoreHI.GetComponent<Text> ();
		HighScore.text = "1000";

	}
	

	void Update () {
		//gets current position of mouse
		Vector3 mousePos2D = Input.mousePosition;
		//sets how far mouse is in a 3D space
		mousePos2D.z = -Camera.main.transform.position.z;
		//convert the point from 2Dscreen space into a 3D game world
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

		//move basket with mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	void OnCollisionEnter(Collision coll){

		int score = 0;
		// hitting basket
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);
			score = int.Parse (scoreGT.text);
			score += 100; //add 100 points
			scoreGT.text = score.ToString();
		}
		if(score > 1000)
		{
			HighScore.text = score.ToString();	
		}
	}
}
