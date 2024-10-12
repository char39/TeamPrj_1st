
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

3. clear 조건
- Pig.cs에서 OnDisable OnEnable 함수로 PigCnt 넘김
- Gamemanager 스크립트 만들어서 여기서 Game clear, Game Over 판단

4. clear 하면 star 띄우고 다음 행성 스프ㅏㄹ이트 바꾸ㅝ

5. AllManageMent - canvas_score - Board - menu , replay빼고 구현

6. 오른쪽 상단 score, highscore
왼쪽 상단 pause Button

========================
1. clear 했을 때 UI 바로 나옴 -> 속도가 어떤 값 미만일 때 LevelManager에서 UI 띄우도록

 - 걍 내 생각인데 DataList.data[roomidx].score가 0일 때만 replay 했을 때 UI true, false 잘 되는 것 같음 왜일까;;;

2. 현재 점수가 최고 점수보다 낮으면 점수 변경 막는건 알겠는데 그래도 현재 점수가 몇 점인지 보여는 줘야됨
 - 점수보여주는건 했는데 별 표시가 좀 에반데 => 완 ㅋㅋ

