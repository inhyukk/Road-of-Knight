using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public EnergyBar PlayerHpBar;
    public EnergyBar EnemyHpBar;
    public Canvas canvas;
    GameObject Enemy;
    RectTransform enemyhpBar;

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
    [HideInInspector] public int EnemyAtkPower = 0;
    [HideInInspector] public float EnemyAtkSpeed = 0f;
    [HideInInspector] public int EnemyCount = 0;     //스테이지
    [HideInInspector] public int MaxEnemyCount = 0;  //스테이지


    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;

        MaxUpgradeLevel = 50;

        PlayerHp = 100;
        MaxPlayerHp = PlayerHp;
        PlayerHpLevel = 1;
        PlayerHpPrice = 10;

        PlayerAtkPower = 1;
        PlayerAtkLevel = 1;
        PlayerAtkPrice = 10;

        PlayerAtkSpeed = 1.0f;
        PlayerAtkSpeedLevel = 1;
        PlayerAtkSpeedPrice = 10;

        coin = 100000;

        EnemyHp = 10;
        MaxEnemyHp = EnemyHp;
        EnemyAtkPower = 1;
        EnemyAtkSpeed = 1.0f;
        EnemyCount = 0;
        MaxEnemyCount = 20;

        Enemy = GameObject.FindGameObjectWithTag("Enemy");

        enemyhpBar = Instantiate(EnemyHpBar, canvas.transform).GetComponent<RectTransform>();
    }

    void Update()
    {
        PlayerHpBar.SetValueMin(0);
        PlayerHpBar.SetValueCurrent((int)PlayerHp);
        PlayerHpBar.SetValueMax((int)MaxPlayerHp);

        EnemyHpBar.SetValueMin(0);
        EnemyHpBar.SetValueCurrent((int)EnemyHp);
        EnemyHpBar.SetValueMax((int)MaxEnemyHp);

        float height = 1.4f;


        Vector3 _enemyhpBarPos =
            Camera.main.WorldToScreenPoint(new Vector3(Enemy.transform.position.x, Enemy.transform.position.y + height, 0));
        enemyhpBar.position = _enemyhpBarPos;

        if(EnemyCount >= MaxEnemyCount)
        {
            //다음 스테이지
        }

        if(PlayerHp <= 0)  //사망
        {
            PlayerHp = 0;

            Player.playerstate = Player.PLAYERSTATE.DEATH;
        }
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