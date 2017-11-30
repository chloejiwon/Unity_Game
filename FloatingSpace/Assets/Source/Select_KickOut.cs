using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_KickOut : MonoBehaviour {


	public GameObject character;
	public bool Clicked;

	public GameObject GameOver;
	bool gameOver;

	// Use this for initialization
	void Start () {
		Clicked = false;
		gameOver = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (Clicked) {
			Clicked = false;
			if (gameOver) {

				GameOver.SetActive (true);

				this.transform.parent.GetChild(0).gameObject.SetActive(false);
				this.transform.parent.GetChild(1).gameObject.SetActive(false);
				this.transform.parent.GetChild(2).gameObject.SetActive(false);
				this.transform.parent.gameObject.SetActive(false);
			   

			}
		}
	}
	public void Click()
	{
		if (gameObject.name == "YES")
		{
			print ("Yes");
			// Want to kick out

			//Game Over
			gameOver = true;

		}
		else
		{
			print ("No");
			// Don't want to kick out anyone
			//아무 일도 벌어지지 않고 그냥 지나간다...
			gameOver = false;
		}
		Clicked = true;
	}

}
