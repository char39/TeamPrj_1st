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



GameManage - 아래 클래스들을 관리
UIManage - UI 관리
LevelManage - Level 관리, clear 판단(AddPig, RemovePig)
SceneManage - Scene 관리
SoundManage 

- wave 들어가면 bird next military a2
- 행성으로 떨어지면 collision01
- 대기 들어감 EnterAtmosphere
- 대기    나감 ExitAtmosphere
// - highScore 갱신했을 때 highscore
- clear 했을 때 level clear military a1
- fail 했을 때 level failed piglets a2
- 슬링샷 당길 때 slingshot streched
- 날아갈 때 bird shot-a2
// - 뒤로가기 눌렀을 때 ButtonBack
- pig 얼면 light damage a3