using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {




	void Start () {
		
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
		// hitting basket
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);
		}
	}
}
