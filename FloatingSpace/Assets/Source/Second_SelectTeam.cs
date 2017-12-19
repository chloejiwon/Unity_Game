using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_SelectTeam : MonoBehaviour {

	//sound effects
	public AudioClip HappySound;
	public AudioSource Happy;
	public AudioClip UhohSound;
	public AudioSource Uhoh;

	//temp
	public GameObject character;

	//When Kick Out
	public GameObject kickOut;

	//When rejected
	public GameObject Rejected;
	public GameObject Selected;

	public npc1 NPC;
	public bool Clicked;
	public Second_Dialogue Talk;

	public string npc_name;

	int npc_num;


	// Use this for initialization
	void Start () {
		Talk = FindObjectOfType<Second_Dialogue>();
		NPC = FindObjectOfType<npc1>();
		Clicked = false;
		Rejected.SetActive (false);
		Selected.SetActive (false);

		Happy.clip = HappySound;
		Uhoh.clip = UhohSound;
	}

	// Update is called once per frame
	void Update () {


		if (Clicked)
		{

			// 다음꺼 부를 필요 없음
//			print(NPC.name);


			Clicked = false;

			Talk.finish = true;

			Debug.Log ("---Select_Team-----");
			Debug.Log (Talk.CharName);
			//NPC.destroyWhenFinished (Talk.CharName);
			character.GetComponent<npc1>().destroyWhenFinished(character.name);

			PlayerController player = FindObjectOfType<PlayerController> ();

			player.gameObject.GetComponent<PlayerController> ().canMove = true;
			player.gameObject.GetComponent<PlayerController> ().hasFriend = false;

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
			NPC =FindObjectOfType<npc1>();
			character = GameObject.Find (npc_name);
			Debug.Log (character.GetComponent<npc1> ().Score);
			if (character.GetComponent<npc1>().judge())
			{
				PlayerController player = FindObjectOfType<PlayerController>();

				int num = player.MemberNumber;
				if(num < player.Members.Length){
				//	SetNpcNum ();
					Debug.Log (npc_num);
					Debug.Log (NPC.name);
					Debug.Log (character.name);
					if (character.name == "Character1") {
						npc_num = 1;
					} else if (character.name == "Character2") {
						npc_num = 2;
					} else if (character.name == "Character3") {
						npc_num = 3;
					} else if (character.name == "Character4") {
						npc_num = 4;
					}
					// why number does not change ??? :(...
					player.Members[player.MemberNumber] = npc_num;
					player.MemberNumber++;
					print("합격!");

					//Sound Effect!!
					Happy.Play();

					Selected.SetActive (true);

				}
			else {
					// 3명 이제 넘었다 !
					// 더이상 ... 멤버를 할 수 없습니다.
					// 퇴출 창 띄워야됨
					print("3명 넘음 퇴출하시겠습니까?");
					kickOut.SetActive(true);
					kickOut.transform.GetChild (0).gameObject.SetActive (true);
					kickOut.transform.GetChild (1).gameObject.SetActive (true);
					kickOut.transform.GetChild (2).gameObject.SetActive (true);

				}

				//print(player.Members[0]);
			}
			else
			{
				//거절당하셧습니다..
				print("you are rejected!");

				//Sound Effect
				Uhoh.Play();

				Rejected.SetActive (true);

			}
	
		}
		else
		{
			character = GameObject.Find (npc_name);
			print ("No");
			// Team하기 시러욧
			//아무 일도 벌어지지 않고 그냥 지나간다...

		}
		Clicked = true;
	}
	void SetNpcNum(){

		if (!NPC) {
			Debug.Log ("SetNPC NUm  들ㅓㅘ?");
			Debug.Log (NPC.name);
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
	}
}