using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

	//Hingejointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;
	//画面の幅中央
	public int center = Screen.width / 2;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);
			if(touch.phase == TouchPhase.Began){

				if (Input.touchCount >= 2) {
					SetAngle (this.flickAngle);
				} else if (Input.touchCount == 1) {
					if (touch.position.x < center && tag == "LeftFripperTag") {
						SetAngle (this.flickAngle);
					} else if (touch.position.x >= center && tag == "RightFripperTag") {
						SetAngle (this.flickAngle);
					}
				}
			}
			else if(touch.phase == TouchPhase.Ended){
				SetAngle (this.defaultAngle);
			}
		}
	}
	//フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring JointSpr = this.myHingeJoint.spring;
		JointSpr.targetPosition = angle;
		this.myHingeJoint.spring = JointSpr;
	}
}
