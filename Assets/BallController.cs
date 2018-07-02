using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	/** ボールが見える可能性があるz軸の最大値 */
	private float visiblePosZ = -6.5f;
	private GameObject gameoverText;
	/** スコア */
	private int score = 0;
	private GameObject scoreText;

	// Use this for initialization
	void Start () {
		this.gameoverText = GameObject.Find ("GameOverText");
		this.scoreText = GameObject.Find ("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.z < this.visiblePosZ) {
			this.gameoverText.GetComponent<Text>().text = "Game Over";
		}
	}

	void OnCollisionEnter(Collision other){
		// スコア加算＆表示
		if (other.gameObject.tag == "SmallStarTag") {
			score += 10;
		} else if (other.gameObject.tag == "LargeStarTag") {
			score += 20;
		} else if (other.gameObject.tag == "SmallCloudTag") {
			score += 30;
		} else if (other.gameObject.tag == "LargeCloudTag") {
			score += 40;
		}
		this.scoreText.GetComponent<Text>().text = score.ToString();
	}
}
