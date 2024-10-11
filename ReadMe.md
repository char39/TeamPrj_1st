
게임 끝나는 조건이 pig(5000)가 다 없어졌는지
그러면 이제 UI 나타나서 prebird가 남은 수만큼 + 10000 해서 score에 넣으면 됨
bubble 300
얼음소행성 big 파괴 2300
얼음소행성 medium 파괴 1300
얼음소행성 small 파괴 800

얼음끼리 부딪히면 점수 올릴건데


1단계
prebird 3개

1만 1개
2만3천 2개
4만부터 별3개




reset됐을 때 star sprite 초기화
replay 하고 씬 불러올 때 canvas UI off


1. 충돌시 +점수

2. Dictionary
* Dictionary의 List에 bird순서
- LevelData.cs에 AddBirdsInOrder() 생성
- gamemanage.cs SetBirdOrder()를 만들어 bird의 순서 설정
                Start()에서 SetBirdOrder() 호출

* Dictionary +bool변수 clear
- GameManagerField에 있는 isClear 지우고 LevelData에 bool 변수 isClear를 선언해 DataList.starScore[1].isClear = true;로 변경

* slingshot.sc
- 

3. clear 조건


pig 남음 

4. clear 하면 star 띄우고 다음 행성 스프ㅏㄹ이트 바꾸ㅝ

5. AllManageMent - canvas_score - Board - menu , replay빼고 구현

6. 오른쪽 상단 score, highscore
왼쪽 상단 pause Button