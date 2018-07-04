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

		// 発展課題：タッチでフリッパーを操作
		int halfWidth = Screen.width / 2;
		if (Input.touchCount > 0) {
			bool leftOn = false;
			bool rightOn = false;
			// 上げるためのタッチがあるか確認
			for (int i = 0; i < Input.touchCount; ++i){
				if (tag == "LeftFripperTag") {
					if (Input.GetTouch (i).position.x < halfWidth) {
						if (Input.GetTouch (i).phase == TouchPhase.Began
							|| Input.GetTouch (i).phase == TouchPhase.Moved
							|| Input.GetTouch (i).phase == TouchPhase.Stationary) {
							leftOn = true;
						}
					}
				}
				if (tag == "RightFripperTag") {
					if (Input.GetTouch (i).position.x > halfWidth) {
						if (Input.GetTouch (i).phase == TouchPhase.Began
							|| Input.GetTouch (i).phase == TouchPhase.Moved
							|| Input.GetTouch (i).phase == TouchPhase.Stationary) {
							rightOn = true;
						}
					}
				}
			}
			// タッチ状況に応じて上げ下げ
			if (tag == "LeftFripperTag") {
				if (leftOn) {
					SetAngle (this.flickAngle);
				} else {
					SetAngle (this.defaultAngle);
				}
			}
			if (tag == "RightFripperTag") {
				if (rightOn) {
					SetAngle (this.flickAngle);
				} else {
					SetAngle (this.defaultAngle);
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
