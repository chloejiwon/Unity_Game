using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_SelectTeam : MonoBehaviour {


	public npc1 NPC;
	public bool Clicked;
	public Second_Dialogue Talk;


	// Use this for initialization
	void Start () {
		Talk = FindObjectOfType<Second_Dialogue>();
		NPC = FindObjectOfType<npc1>();
		Clicked = false;
	}

	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown(KeyCode.Return))
//			Clicked = true;
		if (Clicked)
		{

			// 다음꺼 부를 필요 없음
			print(NPC.name);
			Clicked = false;
			Talk.finish = true;


			this.transform.parent.GetChild(0).gameObject.SetActive(false);
			this.transform.parent.GetChild(1).gameObject.SetActive(false);
			this.transform.parent.GetChild(2).gameObject.SetActive(false);
			print(transform.parent);
			this.transform.parent.gameObject.SetActive(false);
		}
	}
	public static void _start()
	{
		print("---SElect Team불러짐----");
		Character1._stop();

	}
	void OnMouseDown()
	{
		print("************SELECT_TEAM************");
		if (gameObject.name == "YES")
		{
			//Team설정한것
	/*		if (Character1.judge())
			{
				PlayerController player = FindObjectOfType<PlayerController>();
				player.Members[0] = FindObjectOfType<Character1>().name;
				print("합격!");
				print(player.Members[0]);
			}
			else
			{
				//거절당하셧습니다..
			}*/
		}
		else
		{
			// Team하기 시러욧
			//아무 일도 벌어지지 않고 그냥 지나간다...

		}
		Clicked = true;
	}
}
