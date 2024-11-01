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


1~3번 음악은 테마곡
4번 음악 PlanetSelectScene, 행성_SelectLevel

5번 음악은 Cold, Moon의 Level play Bgm
6번 음악은 Egg의 Level 노래

1. 프로젝트 개요 및 게임 컨셉
프로젝트 목표 및 기획 의도
참고한 원작 게임 소개 (앵그리버드 스페이스)
개발 기간과 사용한 엔진 및 툴 (Unity, C#)
게임의 주요 규칙 및 플레이 방식
  새총을 사용하여 새를 발사
  모든 레벨에는 플레이어가 새를 사용하여 터뜨려야 하는 돼지가 존재
  플레이어가 레벨의 모든 돼지를 터뜨리지 못하면 레벨 실패 화면이 나타남
  돼지를 모두 터뜨리는 데 성공하면 승리하고 다음 레벨로 넘어감
  레벨을 완료할 때 플레이어는 받은 점수에 따라 별 1개, 2개 또는 3 개를 받음

  중력장이 있어서 모든 물체와 캐릭터를 중심으로 끌어당김
  중력장 밖에 있을 때 캐릭터와 물체는 운동량을 잃을 때까지 직선으로 이동하는데 이 경우 움직이지 않음
게임의 전체적인 구조 및 흐름

2. 개발 과정 및 주요 기능
주요 기능 (캐릭터, 중력, 레벨 디자인 등)
주요 기능 구현 (점수 시스템, 충돌 감지, 카메라 이동 등)
사용한 알고리즘 및 주요 코드 설명
UI 디자인 및 구성 요소 설명 (점수 표시, 리트라이 버튼 등)
오브젝트(프리팹, 버블) 설명

3. 결과물 및 향후 계획
게임 플레이 스크린샷 또는 GIF, 시연 영상
완성된 주요 기능 설명 (점수 증가, 장애물 반응, 스프라이트 변화)
향후 개선 계획 (추가하고 싶은 부분이나 업데이트할 기능)
프로젝트를 통해 배운 점과 성장한 부분


Script
  >Common
    >CameraMove
      CameraFolloPGKSBird.cs
      MoveCameraByDrag.cs
    >Data
      LevelData.cs
      LevelDataList.cs
      LevelRoomSize.cs
      SceneList.cs
    >Manage
      GameManage.cs
      SoundManage.cs              PlaySound
      SoundManage.Field.cs        Resources.Load<AudioClip>
      LevelManage.cs              Timer(속도 낮으면 켜짐), SetClearOrFailCondition, Clear() Fail()
      LevelManage.Field.cs        선언..
      LevelManage.Public.cs       AddScore, SetStar ~ ResetRoomData, 기타등등
      SceneManage.cs              Scene_N{onClick.AddListener(LoadSelectPlanet)}
      SceneManage.Fiele.cs        tjsdjs
      SceneManage.LoadScene.cs    SceneChange, SceneChangeOnOff, (alpha, blocksRaycasts)
      SceneManage.Public.cs       이동(레벨선택화면으로 이동, 레벨로 이동 등등)
      UIManage.cs                 UIOnOff, 초기화, waveImg가져옴, 언락img, 버튼막기, Clear UI를 띄우고 데이터 저장 SetStarSprite, LevelFailUI
      UIManage.Field.cs           AddListener
      UIManage.Public.cs          Level Data 관련 잇음, Replay, Pause, TimeScale, (planetNum == N )
                                                                                 GameManage.Scene.LoadPLANETselectLevel();
    >Sprite
      Sprites.cs
  >GameStartScene
    GameStartSceneBirdLaunch.cs
    LoadBirdSprites.cs
  >PhysicsLogic
    >Bird
      Bird_Blue.cs
      Bird_Red.cs
      Bird_Yellow.cs
      Bird.cs
      BirdDestroyTime.cs
      BirdPrefs.cs
    >Bubble
      Bubble.cs
      BubblePigMoveCircle.cs
      BubblePigMoveCircleRebound.cs
      BubbleStone.cs
    >Gravity
      >BaseScripts
        GravityField.cs
        IGravityField.cs
      >Gravity Receiver
        GravityFriction.cs
        GravityTarget.cs
      >Planet
        CircularGravvityField.cs
        GravityFieldRadius.cs
        SurfaceRadius.cs
    >Pig
      CirclePlacer.cs
      MoveRandom.cs
      Pig.cs
      SwitchPigOnState.cs
    >Slingshot
      Slingshot.cs
    >Stone
      IceStone.cs
      Stone.cs
      StoneBubble.cs
      StoneRotate.cs
    >Structures
      Blocks.cs
      EggsteroidStone.cs
      Frame.cs
      Frame2.cs
      GrameLong.cs
      GlassBlock.cs
      GlassSquareBlock.cs
      GlassSquareBlock2.cs
      Grass.cs
      StoneBlock.cs
      StoneBlock2.cs
      WoodBlock.cs
      WoodBlock2.cs
      WoodSquareBlock.cs
      WoodTriBlock.cs
    AnglePush.cs
    ColliderDetection.cs
    