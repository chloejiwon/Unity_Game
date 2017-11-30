# Unity_Game
아..게임......ㅎㅎㅎ...


**----------------11/28-------------------**
1. NPC 에 맞는 샘플 text 파일 가지고 scoring system ( npc1 )
2. Second_SelectTeam 으로 npc를 멤버로 받아 들일지 말지 결정가능
3. 멤버의 최대 수는 3명 이거 체크 완료 (Second_SelectTeam.cs + Player)
  3-1) 체크한 후, 넘어서 yes한 상태면 퇴출당하는 거 짜야됨
4. 임시로 너무 빨리 달려서 isTired 된 상태 체크하는거 뺌, 다시 넣어야함


**----------------11/30-------------------**
1. 3명 넘게 멤버 될때 한명 kick out한다고 하면 바로 gameOver (Select_KickOut.cs)
2. Character = GameObject.Find("character name")으로 하면 잘 찾아져서 지워짐
