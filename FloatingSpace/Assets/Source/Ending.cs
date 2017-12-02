using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour {


  // 끝났는지 확인
  public GameObject player;
  public bool isOver;
  public float done_X;

	// Use this for initialsization
	void Start () {
    isOver = false;
    player.Find("player");
	}

	// Update is called once per frame
	void Update () {
    Decide_Ending();

	}

  void Decide_Ending(){
    if(player.transform.position.x>=done_X){
      // when player reached the end (met every characters)
      // as an example
      if(player.MemberNumber == 3){
        // 3명 만났을 때
        
      }else if(player.MemberNumber == 2){

      }else if(player.MemberNumber=1){

      }else {
        // 아무 캐릭터도 고르지 않았을 때
      }

    }

  }
}
