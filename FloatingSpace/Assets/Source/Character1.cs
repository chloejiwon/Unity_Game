using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1 : MonoBehaviour {

	public float rotateSpeed = 1;
	public float self_rotateSpeed = 1;
	public bool canMove=true;
	public bool Die = false;
    public static int Score;
    public GameObject Next;

    public GameObject ChoicePopupBG;

    // Use this for initialsization
    void Start () {
        Score = 0;
        if(Next!=null)
           Next.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!canMove)
			return;
        if (Die)
        {
			Debug.Log ("Die here?");
            Destroy(gameObject);
        }
	//	transform.Rotate (Vector3.back * self_rotateSpeed);
		transform.Rotate (Vector3.up * rotateSpeed);
		
	}

	public void EndOfConversation(){
        /*        if (Score > 100)
                    Die = false;
                else
                    Die = true;*/
  //      Die = true;
	}
    public void CalculateScore(int num)
    {
        Score += num;
    }
    public void InitOthers()
    {
        print("아왜!!!");
        print(gameObject.name);
     //   if (!Dialogue.ENDALL)
  //      {
            if (Next != null)
            {
                print("스노우부르자!!");

                //    Instantiate(Next);
                gameObject.GetComponentInParent<cnr>().back();
                gameObject.GetComponentInParent<cnr>().StartAgain();
                //choice 없애야됨..
              // ChoicePopupBG.SetActive(false);
                Next.SetActive(true);
            //gameObject.SetActive(false);
            }
 //       }
    //    Destroy(gameObject);
       // Instantiate(Next);
    }
    public static void _stop()
    {
       cnr axis = Character1.FindObjectOfType<cnr>();
        axis.Stop();
      //  gameObject.SetActive(false);
    }
    public static void _start()
    {
        cnr axis = Character1.FindObjectOfType<cnr>();
        axis.StartAgain();

        
        //ChoicePopup.SetActive(false);
        //  gameObject.SetActive(false);
    }
    public static bool judge()
    {
        bool result = false;
        if(Score > 100)
        {
            result = true;
            //호감이라는뜻
        }
        else
        {
            //불합격^^
        }
        return result;
    }
}
