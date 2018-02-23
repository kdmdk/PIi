using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	
	private int score = 0; //スコア計算用変数
	//public string scoretxt;

	//scoreを表示するテキスト
	private GameObject scoreText;

	// Use this for initialization
	void Start () {
		score  = 10;
		this.scoreText = GameObject.Find("ScoreText");
	}

	//接触時の処理
	void OnCollisionEnter( Collision collision ){
		string yourTag  = collision.gameObject.tag;

		if (yourTag == "LargeCloudTag") {
			score += 4;
		} else if (yourTag == "LargeStarTag") {
			score += 3;
		} else if (yourTag == "SmallStarTag") {
			score += 1;
		} else if (yourTag == "SmallCloudTag") {
			score += 2;
		}
	}
	void Update () {
		this.scoreText.GetComponent<Text>().text = "SCORE：" + score.ToString ();
	}
}
