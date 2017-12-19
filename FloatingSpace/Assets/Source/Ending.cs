using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour {


	// 끝났는지 확인
	public GameObject player;
	public bool isOver;
	public float done_Z;

	// 여러가지 엔딩들
	public string ending;
	public GameObject Planet;


	//씬매니저
	public GameObject SceneChange;

	// Use this for initialsization
	void Start () {
		isOver = false;
		player = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update () {
		isEnd ();
		if(isOver){
			//Decide_Ending();
			//엔딩을 정한 후에 ~ 
			//씬을 엔딩 씬으로 바꾸자

			SceneManager.LoadScene("Ending");
			//SceneManager.UnloadSceneAsync("3dscene");
			//SceneChange.GetComponent<SceneChange>().ChangeEndingScene();

		}

	}

	void isEnd(){
		// when player reached the end (met every characters)
		// as an example
		if(player.transform.position.z >= done_Z)
			isOver = true;

	}

	void Decide_Ending(){
		// when player reached the end (met every characters)
		// decide the endings according to the choice of members

		switch(player.GetComponent<PlayerController>().MemberNumber){
		case 1:
			// 1명 만났을 때 그 친구에 맞게 
			break;
		case 2:
			break;
		case 3:
			// 3명 만났을 때
			// 각각 케이스별로 조사....(완전 망했다...머야 이 노가다 ㅠ )
			if(player.GetComponent<PlayerController>().Members[0] == 1){
				if(player.GetComponent<PlayerController>().Members[1]==2){
					if(player.GetComponent<PlayerController>().Members[2]==3){
						// Character 1,2,3골랐을 때
						ending = "ending1";
						// 첫번째 엔딩 부과
						// 각 ending name에 해당하는 행성과 panel을 부른다
					}
				}
			}
			break;
		case 0:
			// 아무 캐릭터도 고르지 않았을 때
			ending="nothing";
			break;
		}

		Planet = GameObject.Find(ending);

	}

}