
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
# 2024-10-12
1. clear 했을 때 UI 바로 나옴 -> Bird 속도가 어떤 값 미만일 때 LevelManager에서 UI 띄우도록
- 화면 밖으로 나가는 Bird가 있으면 (삭제) -> 속도 0으로 수정. 그렇게 안해두면 속도가 n일 때라는 조건을 쓸 수가 없음 계속 날아가서
- MoveCameraByDrag.cs의 bgSprite를 public으로 바꿈. Bird.cs에서 쓸거라서
- Bird.cs에서 CheckOutOfBounds()로 화면 밖으로 나갔는지 확인
- Bird.Yellow에서 CheckOutOfBounds() override

- GameManager.cs 에서 clear 조건 Bird 속도 0으로만 만들게 아니라 모든 object의 속도 다 가져와서 n 미만일 때 clear를 해야될 것 같은데
    => clear 조건 그냥 pig 다 없어지고 5초뒤로 해버리면 아주 간단하지 않나.... 그럼 CheckOutOfBounds() 이것도 안써도 되는데..
    점수 나오는 UI 나올 때 뒤에 움직이는 obj 일시정지됨

2. 현재 점수가 최고 점수보다 낮으면 점수 변경 막는건 알겠는데 그래도 현재 점수가 몇 점인지 보여는 줘야됨
 - 점수보여주는건 했는데 별 표시가 좀 에반데 => 완 ㅋㅋ
 - LevelManager에 UI 만들어서 score랑 HighScore 표시
    => on, off를 slingshot 있냐 없냐로 판단



* DataList.data[roomidx].score가 0일 때만 replay 했을 때 UI true, false 잘 되는 것 같음 왜일까;;;