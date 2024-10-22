
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
# 2024-10-12 ~ 24-10-13
1. clear 했을 때 UI 바로 나옴 -> Bird 속도가 어떤 값 미만일 때 LevelManager에서 UI 띄우도록
- 화면 밖으로 나가는 Bird가 있으면 (삭제) -> 속도 n으로 수정. 그렇게 안해두면 속도가 n일 때라는 조건을 쓸 수가 없음 계속 날아가서
  MoveCameraByDrag.cs의 bgSprite를 public으로 바꿈. Bird.cs에서 쓸거라서'''
  Bird.cs에서 CheckOutOfBounds()로 화면 밖으로 나갔는지 확인
  Bird.Yellow에서 CheckOutOfBounds() override

- GameManager.cs 에서 clear 조건 Bird 속도 0으로만 만들게 아니라 모든 object의 속도 다 가져와서 n 미만일 때 clear를 해야될 것 같은데
  => clear 조건 그냥 pig 다 없어지고 5초뒤로 했더니 오류뜸. 흠.
  점수 나오는 UI 나올 때 뒤에 움직이는 obj 일시정지 해야할듯

2. 현재 점수가 최고 점수보다 낮으면 점수 변경 막는건 알겠는데 그래도 현재 점수가 몇 점인지 보여는 줘야됨
- 점수보여주는건 했는데 별 표시가 좀 에반데 => 완 ㅋㅋ
- LevelManager에 UI 만들어서 score랑 HighScore 표시 완
  => on, off를 slingshot 있냐 없냐로 판단
- DataList.starScore[roomidx].stars에 있는걸 바탕으로 UI sprite 변경

3. GameManager.cs에다가 Planet UI 만들어서 DataList.starScore[roomidx].stars에 있는걸 바탕으로 UI sprite 변경 => 애매하게 완
- DataList.data[101].stars 검색해서 이거 수정


* Level_UI true, false 왜이렇게 안되냐





GameManager.cs
  Update()

    ClearCheck()
      if (wave 돼지 수 == 0, 발사대가 존재)
        if (새 클래스 존재, 새 속도가 5 이하)
          datalist의 temp 클리어조건 true
          LevelManage SetStarRating()
      else if (발사대가 존재)
        if (발사대 totalBirds == usedBirds)
          datalist의 temp 클리어조건 false

LevelManage.cs
  Update()

    UpdateSlingShot()     // 현재 맵에 있는 발사대 정보를 업데이트
    if ((int)SceneManage.GetLoadScene() == 100)
      LoadWaveImg();      // Planet 아래에 있는 별 이미지 컴포넌트를 로드
    OnOffScoreUI();       // ScoreUI, InGameUI를 켜고 끔, score, highscore text 업데이트
    if (temp clear조건 참일 때)
      SetStarRating();    // 별 이미지를 업데이트
    if (waveUI 존재, datalist.data[101].stars가 0이 아닐 때)
      SetPlanetStar();    // Planet 아래에 있는 별 이미지를 업데이트

Bird.cs
  CheckOutOfBounds()      // 화면 밖으로 나갔는지 확인
    #2 if () 기존은 BG크기에 맞춰서 자동으로 설정 했다면, 화면 밖 기준을 직접 정하는 것으로 변경


  클리어 조건
    중력을 받는 모든 클래스를 검색해서 속도가 0.2 이하일 때.  #1 (맵 밖으로 나가면 속도는 0이 되게 설정)
    돼지 전부 디짐

    클리어 판정이 되고나서 약 1.5초뒤에 UI가 나오게 하기



* 일시정지
* Clear 판단해서 planet Img 변경
* replay 했을 때 bir



GameManage - 아래 클래스들을 관리
UIManage - UI 관리
LevelManage - Level 관리, clear 판단(AddPig, RemovePig)
SceneManage - Scene 관리

=========
# 241023
1. AnglePush.cs를 wave7에 추가해서 angle 받아서 bird 밀어냄