# UnityProject_TeamNJPD
UNITY TEAM GAME PROJECT_TEAM_NJPD
Vampire Survival Like Game, 2D, 


[Team 나주포대 두 번째 팀 게임 제작 프로젝트, 뱀서라이크 장르, 유니티 플랫폼을 이용하여 제작]


사용언어 : C#


사용툴 : 노션, 유니티(2021.3.2.f1 ver), 깃(포크), Github Desktop


목적 : 
팀프로젝트 진행 중 파트분배의 어려움을 느껴 좀 더 체계적인 팀 빌딩 능력을 기르기 위해, 코드 사용 숙련도 증가를 위해 프로젝트 진행
객체지향의 구조와 게임 구조에 대한 전반적인 이해를 위해 프로젝트 진행


참고 : 
https://youtu.be/MmW166cHj54?si=OMvPGYwgJsbe8ykQ [유튜브 골드메탈 : 뱀서라이크 제작]


[전체코드 위치 및 간략한 설명]
파일위치 : Assets/Script

AudioManager.cs

: 배경음, 레벨업을 했을 때, 몬스터를 처치할 때의 효과음 등을 관리하는 스크립트
Bullet.cs

: 플레이어의 무기를 관리하는 스크립트. 근거리 무기와 원거리 무기의 충돌 시스템 및 관통 시스템을 관리하는 스크립트

Character.cs

: 게임 시작 시, 능력치가 다른 캐릭터를 선택한다. 선택결과에 따라 시작 능력치를 다르게 부여하는 스크립트

Follow.cs

: 체력바의 위치를 캐릭터 포지션 바로 아래에 고정시키도록 한다. 체력바의 좌표를 관리하는 스크립트

GameManager.cs

: 게임의 제한시간, 캐릭터 레벨업, 보상 선택, 몬스터 소환 관리, 게임 승리, 게임 종료, 게임 재시작 시스템을 관리하는 스크립트

Gear.cs

: 무기의 위치를 캐릭터 포지션 특정 위치에 고정시키며, 무기의 레벨업, 레벨업에 따른 능력치 조정을 하는 스크립트

Hand.cs

: 플레이어가 조종하는 캐릭터의 방향이 바뀔 때마다, 캐릭터가 화면 상 소유중인 무기의 위치 및 방향을 변경하는 스크립트

HUD.cs

: 레벨업 UI의 게이지 시스템을 관리하는 스크립트

Item.cs

: 플레이어가 일정량의 몬스터를 처치하여 레벨업을 하면 아이템을 선택하고 획득하게 되는데, 이에 따라 공격력, 이동속도를 갱신하는 스크립트

ItemData.cs

: 근거리무기, 원거리무기, 공격속도 관련 아이템, 이동속도 관련 아이템, 체력 회복 관련 아이템의 이미지, 스크립트 등 데이터를 관리하는 스크립트

LevelUp.cs

: 레벨 업 시 등장하는 보상 선택화면의 사운드, 시간 정지, 보상 목록 출력, 게임 재개에 대해 다루며 전체적인 보상 시스템을 관리하는 스크립트. 

Monster.cs

: 몬스터의 움직임, 플레이어와의 충돌, 피격, 사망, 사망에 따른 경험치 부여, SFX 재생, 넉백 시스템을 관리하는 스크립트

Player.cs

: 캐릭터 조작, 몬스터와의 충돌, 피격, 사망 시스템을 관리하는 스크립트

PoolManager.cs

: 몬스터 프리팹 리스트에 저장되어 있는 몬스터를 번갈아가며 소환하는 스크립트

Reposition.cs

: 캐릭터 이동에 따른 맵의 확장을 실시하는 스크립트

Result.cs

: 게임 승패에 따른 UI를 출력하는 스크립트

Scanner.cs

: 몬스터를 스캔하여 유도형 원거리 무기를 구현하기 위한 스크립트

Spawner.cs

: 캐릭터가 살아있을 때, 일정시간마다 몬스터를 스폰하는 스크립트

Weapon.cs

: 캐릭터 무기의 레벨업에 따른 무기 개수, 대미지, 캐릭터 위치에 따른 배치 위치, 원거리 무기에 대한 발사 방향 등을 관리하는 스크립트



[구현 모습]

![image](https://github.com/user-attachments/assets/a6a082f0-aee7-4b24-a438-1f8417df514f)


[플레이 장면]

![image](https://github.com/user-attachments/assets/2f3b7032-ad27-4781-995f-90908d2702d0)


[레벨업, 선택지 출력]

![image](https://github.com/user-attachments/assets/4183ac18-a2ef-4208-8f17-01ef88c25504)


[게임 실패]

![image](https://github.com/user-attachments/assets/be234f32-a86b-406f-853b-cba68b3d7a1b)


[게임 승리]

![image](https://github.com/user-attachments/assets/cb609bc5-a5a7-4fb8-a0ad-98d3b9c2cd2e)


[실행 방법]

Code -> Download zip -> VamSurLikeProject.exe 파일 실행


전체 파일을 다운받고 유니티 허브로 오픈할 경우 Scene -> SampleScene으로 진입해야 게임실행 가능


[파트 분배]
![1](https://github.com/KORgosu/UnityProject_TeamNJPD/assets/47071344/260ce890-467f-44f7-a13a-a023cf5ba316)
