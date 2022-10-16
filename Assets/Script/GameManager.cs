using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public EnergyBar PlayerHpBar;

    [HideInInspector] public int MaxUpgradeLevel = 0;
    
    public float PlayerHp = 0;
    [HideInInspector] public float MaxPlayerHp = 0;
    [HideInInspector] public int PlayerHpLevel = 0;
    [HideInInspector] public int PlayerHpPrice = 0;
    
    public float PlayerAtkPower = 0;
    [HideInInspector] public int PlayerAtkPowerLevel = 0;
    [HideInInspector] public int PlayerAtkPowerPrice = 0;
    
    [HideInInspector] public float PlayerAtkSpeed = 0f;
    [HideInInspector] public int PlayerAtkSpeedLevel = 0;
    [HideInInspector] public int PlayerAtkSpeedPrice = 0;
    
    public int coin = 0;

    [HideInInspector] public float EnemyHp = 0;
    [HideInInspector] public float MaxEnemyHp = 0;
    [HideInInspector] public float EnemyAtkPower = 0;
    [HideInInspector] public float EnemyAtkSpeed = 0f;
    [HideInInspector] public int EnemyCount = 0;
    [HideInInspector] public int MaxEnemyCount = 0;    
    [HideInInspector] public int StageNum = 0;

    [HideInInspector] public float BossHp = 0;
    [HideInInspector] public float MaxBossHp = 0;
    [HideInInspector] public float BossAtkPower = 0;

    public static GameManager Instance;

    public AudioSource[] sfx;

    private void Awake()
    {
        Instance = this;

        MaxUpgradeLevel = 100;

        MaxPlayerHp = 20f;
        PlayerHp = MaxPlayerHp;
        PlayerHpLevel = 1;
        PlayerHpPrice = 1;

        PlayerAtkPower = 1;
        PlayerAtkPowerLevel = 1;
        PlayerAtkPowerPrice = 1;

        PlayerAtkSpeed = 1.0f;
        PlayerAtkSpeedLevel = 1;
        PlayerAtkSpeedPrice = 1;

        coin = 0;

        MaxEnemyHp = 10;
        EnemyHp = MaxEnemyHp;
        EnemyAtkPower = 1;
        EnemyAtkSpeed = 1.0f;
        EnemyCount = 0;
        MaxEnemyCount = 20;
        StageNum = 1;

        MaxBossHp = MaxEnemyHp;
        BossHp = EnemyHp;
        BossAtkPower = EnemyAtkPower;

        PlayerHpBar.SetValueMin(0);
        PlayerHpBar.SetValueCurrent((int)MaxPlayerHp);
        PlayerHpBar.SetValueMax((int)MaxPlayerHp);
    }

    private void Start()
    {
        sfx[0].PlayDelayed(0);
        sfx[4].PlayOneShot(sfx[4].clip);
    }

    void Update()
    {
        if (PlayerHp <= 0)  //플레이어 사망
        {
            PlayerHp = 0;

            Player.playerstate = Player.PLAYERSTATE.DEATH;
        }
        if (EnemyHp <= 0) Enemy.enemystate = Enemy.ENEMYSTATE.DEATH;
        
        PlayerHpBar.SetValueCurrent((int)PlayerHp);
    }

    public void UpgradeFn(int level, float currstatus, int price,
        Text LevelText, Text currentStatusText, Text PriceText, Text UpgradeText, Button UpgradeButton, bool canbuy)
    {        
        if (canbuy)
        {
            LevelText.text = level.ToString() + " Lv";
            currentStatusText.text = currstatus.ToString();
            PriceText.text = price.ToString() + "G";
        }
        
        if (level == MaxUpgradeLevel - 1)
        {
            LevelText.text = "Max Lv";
            PriceText.enabled = false;
            UpgradeText.enabled = false;
            UpgradeButton.enabled = false;
        }
    }
}