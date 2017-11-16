using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class SpaceControls : MonoBehaviour {
	Controller controller;

	public float spaceshipSpeed = 10;

	// Use this for initialization
	void Start () {
		controller = new Controller();
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame();
		if (frame.Hands.Count == 2) {
			Hand leftHand;
			Hand rightHand;
			if (frame.Hands [0].IsLeft) {
				leftHand = frame.Hands [0];
				rightHand = frame.Hands [1];
			} else {
				rightHand = frame.Hands [0];
				leftHand = frame.Hands [1];
			}

			//Debug.Log (leftHand.PalmPosition);
			//Debug.Log (rightHand.PalmPosition);

			// Lateral Move = Roulis
			float lateralMove = leftHand.PalmPosition[1] - rightHand.PalmPosition[1];
			//lateralMove /= 100/((leftHand.PalmVelocity[1] + rightHand.PalmVelocity[1])/2);
			//lateralMove /= 1000;
			//transform.Translate (Vector3.right * lateralMove * Time.deltaTime);
			//transform.RotateAround (transform.localPosition, Vector3.back, lateralMove);
			transform.Rotate (Vector3.back * lateralMove * Time.deltaTime);

			// Vertical Move = Tangage
			float verticalMove = (leftHand.Direction[1] + rightHand.Direction[1])/2;
			Debug.Log (verticalMove);
			Vector3 verticalDir = Quaternion.AngleAxis(90*verticalMove,Vector3.left) * Vector3.forward;

			//transform.Translate (10 * verticalDir * Time.deltaTime);
			//transform.RotateAroundLocal (transform.localPosition, Vector3.left, verticalMove);
			transform.Rotate (Vector3.left * 100 * verticalMove * Time.deltaTime);

			//Lacet
			float rotateMove = rightHand.PalmPosition[2] - leftHand.PalmPosition[2];
			//rotateMove /= 100;
			//transform.RotateAroundLocal (transform.localPosition, Vector3.up, rotateMove);
			transform.Rotate (Vector3.up * rotateMove * Time.deltaTime);


			//ULTRA BOOST MOTOR VULCAN BY ELON MUSK
			transform.Translate(Vector3.forward * spaceshipSpeed * Time.deltaTime);
		}
	}
}
