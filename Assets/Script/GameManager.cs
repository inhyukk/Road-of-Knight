using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public EnergyBar PlayerHpBar;

    [HideInInspector] public int MaxUpgradeLevel = 0;
    
    [HideInInspector] public float PlayerHp = 0;
    [HideInInspector] public float MaxPlayerHp = 0;
    [HideInInspector] public int PlayerHpLevel = 0;
    [HideInInspector] public int PlayerHpPrice = 0;
    
    [HideInInspector] public float PlayerAtkPower = 0;
    [HideInInspector] public int PlayerAtkLevel = 0;
    [HideInInspector] public int PlayerAtkPrice = 0;
    
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

    private void Awake()
    {
        Instance = this;

        MaxUpgradeLevel = 50;

        MaxPlayerHp = 10;
        PlayerHp = MaxPlayerHp;
        PlayerHpLevel = 1;
        PlayerHpPrice = 10;

        PlayerAtkPower = 10;
        PlayerAtkLevel = 1;
        PlayerAtkPrice = 10;

        PlayerAtkSpeed = 1.0f;
        PlayerAtkSpeedLevel = 1;
        PlayerAtkSpeedPrice = 10;

        coin = 100000;

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

    private void Update()
    {
        if (PlayerHp <= 0)  //플레이어 사망
        {
            PlayerHp = 0;

            Player.playerstate = Player.PLAYERSTATE.DEATH;
        }
        PlayerHpBar.SetValueCurrent((int)PlayerHp);
    }

    public void UpgradeFn(int level, float currstatus, int price,
        Text LevelText, Text currentStatus, Text PriceText,  Button UpgradeButton)
    {        
        if (coin >= price)
        {
            PriceText.color = Color.green;

            LevelText.text = level.ToString() + " Lv";
            currentStatus.text = currstatus.ToString();
            PriceText.text = price.ToString() + "G";
        }
        else PriceText.color = Color.red;
        
        if (level == MaxUpgradeLevel)
        {
            LevelText.text = "Max Lv";
            PriceText.enabled = false;
            UpgradeButton.enabled = false;
        }
    }
}