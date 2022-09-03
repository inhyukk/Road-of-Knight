using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnergyBar PlayerHpBar;
    public EnergyBar EnemyHpBar;
    public Canvas canvas;
    GameObject Enemy;
    RectTransform enemyhpBar;

    [HideInInspector] public int MaxUpgradeLevel = 0;
    
    [HideInInspector] public int PlayerHp = 0;
    [HideInInspector] public int MaxPlayerHp = 0;
    [HideInInspector] public int PlayerHpLevel = 0;
    [HideInInspector] public int PlayerHpPrice = 0;
    
    [HideInInspector] public int PlayerAtkPower = 0;
    [HideInInspector] public int PlayerAtkLevel = 0;
    [HideInInspector] public int PlayerAtkPrice = 0;
    
    [HideInInspector] public float PlayerAtkSpeed = 0f;
    [HideInInspector] public int PlayerAtkSpeedLevel = 0;
    [HideInInspector] public int PlayerAtkSpeedPrice = 0;
    
    public int coin = 0;

    [HideInInspector] public int EnemyHp = 0;
    [HideInInspector] public int MaxEnemyHp = 0;
    [HideInInspector] public int EnemyAtkPower = 0;
    [HideInInspector] public float EnemyAtkSpeed = 0f;
    [HideInInspector] public int EnemyCount = 0;     //스테이지
    [HideInInspector] public int MaxEnemyCount = 0;  //스테이지


    private static GameManager instance;

    private void Awake()
    {
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

        PlayerHpBar = gameObject.GetComponent<EnergyBar>();
        EnemyHpBar = gameObject.GetComponent<EnergyBar>();

        Enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void Start()
    {
        enemyhpBar = Instantiate(EnemyHpBar, canvas.transform).GetComponent<RectTransform>();
    }

    void Update()
    {
        PlayerHpBar.SetValueMin(0);
        PlayerHpBar.SetValueCurrent(PlayerHp);
        PlayerHpBar.SetValueMax(MaxPlayerHp);

        EnemyHpBar.SetValueMin(0);
        EnemyHpBar.SetValueCurrent(EnemyHp);
        EnemyHpBar.SetValueMax(MaxEnemyHp);

        float height = 1.4f;


        Vector3 _enemyhpBarPos =
            Camera.main.WorldToScreenPoint(new Vector3(Enemy.transform.position.x, Enemy.transform.position.y + height, 0));
        enemyhpBar.position = _enemyhpBarPos;

        if(EnemyCount >= MaxEnemyCount)
        {
            //다음 스테이지
        }
    }        

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
}
