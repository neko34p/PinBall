using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
	private HingeJoint myHingeJoint;
	private float defaultAngle = 20;
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		this.myHingeJoint = GetComponent<HingeJoint> ();
		SetAngle (this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}

		// TODO 動かす
		int halfWidth = Screen.width / 2;
		if (Input.touchCount > 0) {
			for (int i = 0; i < Input.touchCount; ++i)
			{
				// 画面の左側
				if (Input.GetTouch (i).position.x < halfWidth && tag == "LeftFripperTag") {
					if (Input.GetTouch (i).phase == TouchPhase.Began) {
						SetAngle (this.flickAngle);
					}
					if (Input.GetTouch (i).phase == TouchPhase.Ended) {
						SetAngle (this.defaultAngle);
					}
				}
				// 画面の右側
				if (Input.GetTouch (i).position.x > halfWidth && tag == "RightFripperTag") {
					if (Input.GetTouch (i).phase == TouchPhase.Began) {
						SetAngle (this.flickAngle);
					}
					if (Input.GetTouch (i).phase == TouchPhase.Ended) {
						SetAngle (this.defaultAngle);
					}
				}
			}
		}
	}

	public void SetAngle(float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}
