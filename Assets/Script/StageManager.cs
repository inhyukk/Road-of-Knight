using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Enemy;

public class StageManager : MonoBehaviour
{
    public GameObject player;
    public EnergyBar EnemyHpBar;
    public Canvas canvas;
    RectTransform enemyhpBar;

    public GameObject Enemy;  //소환용
    GameObject enemytemp;
    EnergyBar enemyhpbartemp;

    public Text StageText;
    public Text EnemyCountText;
    public Text BossText;

    Vector3 playerReturnPos = Vector3.zero;

    int[] enemyhpTable = { 10, 20, 30, 50, 100 };
    int[] enemyatkTable = { 1, 5, 10, 20, 30 };
    int[] GiveCoinTable = { 500, 1000, 5000, 10000, 50000 };


    void Start()
    {
        BossText.enabled = false;

        playerReturnPos = player.transform.position;
        enemyhpBar = Instantiate(EnemyHpBar, canvas.transform).GetComponent<RectTransform>();
        StageText.text = GameManager.Instance.StageNum + " Stage";

        enemyhpbartemp = GameObject.FindGameObjectWithTag("EnemyHpBar").GetComponent<EnergyBar>();
        enemytemp = null;

        enemyhpbartemp.SetValueMin(0);
        enemyhpbartemp.SetValueCurrent((int)GameManager.Instance.MaxEnemyHp);  //초기화
        enemyhpbartemp.SetValueMax((int)GameManager.Instance.MaxEnemyHp);
        SpawnEnemy();  //기본생성
    }

    void Update()
    {
        int i = GameManager.Instance.StageNum / 10;

        enemyhpbartemp.SetValueCurrent((int)GameManager.Instance.EnemyHp);
        enemyhpbartemp.SetValueMax((int)GameManager.Instance.MaxEnemyHp);

        if(enemystate == ENEMYSTATE.DEATH) GameManager.Instance.coin += GiveCoinTable[i];

        if (!enemytemp)
        {
            if (GameManager.Instance.EnemyCount == GameManager.Instance.MaxEnemyCount)  //다음 스테이지
            {
                GameManager.Instance.EnemyCount = 0;
                GameManager.Instance.StageNum++;
                StageText.text = GameManager.Instance.StageNum + " Stage";
                BossText.enabled = false;

                GameManager.Instance.MaxEnemyHp -= GameManager.Instance.MaxBossHp - GameManager.Instance.MaxEnemyHp;
                GameManager.Instance.EnemyAtkPower -= GameManager.Instance.BossAtkPower - GameManager.Instance.EnemyAtkPower;
                if (i > 4)
                {
                    i = 0;
                    GiveCoinTable[i] *= 10;
                }
                GameManager.Instance.MaxEnemyHp += enemyhpTable[i];
                GameManager.Instance.EnemyAtkPower += enemyatkTable[i];

                player.transform.position = playerReturnPos;
                GameManager.Instance.PlayerHp = GameManager.Instance.MaxPlayerHp;
                Player.playerstate = Player.PLAYERSTATE.RUN;

                GameManager.Instance.sfx[4].PlayOneShot(GameManager.Instance.sfx[4].clip);
            }

            if (GameManager.Instance.EnemyCount == GameManager.Instance.MaxEnemyCount - 1)  //보스소환
            {
                MakeBoss();
            }
            else SpawnEnemy();
        }
        else
        {   //달려나옴
            enemytemp.transform.position = Vector3.MoveTowards(enemytemp.transform.position, new Vector3(6.4f, 2.5f, 0), 1.0f);
            EnemyHpbarPos();
        }
    }

    void SpawnEnemy()
    {
        if (GameManager.Instance.EnemyCount <= GameManager.Instance.MaxEnemyCount)  //일반몹소환
        {
            enemystate = ENEMYSTATE.IDLE;  //상태 초기화
            GameManager.Instance.EnemyHp = GameManager.Instance.MaxEnemyHp;  //체력 초기화
            Instantiate(Enemy).gameObject.transform.position = new Vector3(10.0f, 2.5f, 0);  //프리팹 몬스터 소환
            enemytemp = GameObject.FindGameObjectWithTag("Enemy").gameObject;  //인게임 몬스터 등록
            GameManager.Instance.EnemyCount++;  //소환될 때 카운트 증가
            EnemyCountText.text = GameManager.Instance.EnemyCount + " / " + GameManager.Instance.MaxEnemyCount;
        }
    }

     void MakeBoss()
     {
        BossText.enabled = true;

        GameManager.Instance.MaxBossHp += GameManager.Instance.MaxBossHp * 0.5f;
        GameManager.Instance.BossAtkPower += GameManager.Instance.BossAtkPower * 0.5f;  //보스 스탯 설정
        if (GameManager.Instance.StageNum % 10 == 0)
        {
            GameManager.Instance.MaxBossHp *= 2f;
            GameManager.Instance.BossAtkPower *= 2f;
        }

        SpawnEnemy();
        enemytemp.transform.localScale *= 1.5f;
     }

    void EnemyHpbarPos()
    {
        float height = 1.4f;

        Vector3 _enemyhpBarPos =
            Camera.main.WorldToScreenPoint(new Vector3(enemytemp.transform.position.x, enemytemp.transform.position.y + height, 0));
        enemyhpBar.position = _enemyhpBarPos;
    }
}