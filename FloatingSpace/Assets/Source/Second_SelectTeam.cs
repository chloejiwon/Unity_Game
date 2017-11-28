using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_SelectTeam : MonoBehaviour {


	public npc1 NPC;
	public bool Clicked;
	public Second_Dialogue Talk;

	int npc_num;


	// Use this for initialization
	void Start () {
		Talk = FindObjectOfType<Second_Dialogue>();
		NPC = FindObjectOfType<npc1>();
		Clicked = false;
	}

	// Update is called once per frame
	void Update () {

		// NPC Name 
		NPC = FindObjectOfType<npc1>();
		if (!NPC) {
			if (NPC.name == "Character1") {
				npc_num = 1;
			} else if (NPC.name == "Character2") {
				npc_num = 2;
			} else if (NPC.name == "Character3") {
				npc_num = 3;
			} else if (NPC.name == "Character4") {
				npc_num = 4;
			}
		}

		if (Clicked)
		{

			// 다음꺼 부를 필요 없음
			print(NPC.name);

			Clicked = false;

			Talk.finish = true;

			Debug.Log (Talk.CharName);
			NPC.destroyWhenFinished (Talk.CharName);

			PlayerController player = FindObjectOfType<PlayerController> ();

			player.gameObject.GetComponent<PlayerController> ().canMove = true;

			this.transform.parent.GetChild(0).gameObject.SetActive(false);
			this.transform.parent.GetChild(1).gameObject.SetActive(false);
			this.transform.parent.GetChild(2).gameObject.SetActive(false);
			this.transform.parent.gameObject.SetActive(false);
		}
	}
	public void _start()
	{
		print("---SElect Team불러짐----");
		NPC = FindObjectOfType<npc1>();
	}
	public void Click()
	{
		print("************SELECT_TEAM************");
		if (gameObject.name == "YES")
		{
			print ("Yes");
			//Team설정한것
			if (NPC.GetComponent<npc1>().judge())
			{
				PlayerController player = FindObjectOfType<PlayerController>();

				int num = player.MemberNumber;
				if(num < player.Members.Length){
			
					player.Members[player.MemberNumber] = npc_num;
					player.MemberNumber++;
					print("합격!");
				}
			else {
					// 3명 이제 넘었다 !
					// 더이상 ... 멤버를 할 수 없습니다.
					// 퇴출 창 띄워야됨
					print("3명 넘음 퇴출하시겠습니까?");

				}

				//print(player.Members[0]);
			}
			else
			{
				//거절당하셧습니다..
				print("you are rejected!");
			}
	
		}
		else
		{
			print ("No");
			// Team하기 시러욧
			//아무 일도 벌어지지 않고 그냥 지나간다...

		}
		Clicked = true;
	}
}