using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public Ball ball;
	public Text scoreText;
	public int score;


	private static GameManager instance = null;
	public static GameManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameObject("GameManager").AddComponent<GameManager>();
			}

			return instance;
		}
	}

	private void OnEnable()
	{
		instance = this;
	}

	public void UpdateScore()
	{
		score += 10;
		scoreText.text = score.ToString();
	}
	public void Death()
	{
		StartCoroutine(RestartScene());
		Instantiate(ball.deathEffect, ball.transform.position, Quaternion.identity, ball.transform);
		ball.gamerunning = false;
	}

	public IEnumerator RestartScene()
	{
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
