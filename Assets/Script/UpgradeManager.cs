using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    int[] CoinTable = { 1, 10, 50, 100, 200, 500, 1000, 3000, 5000, 10000 };
    int[] AttackPowerTable = { 1, 5, 10, 30, 50, 100, 200, 500, 1000, 2000 };
    int[] HpTable = { 10, 30, 50, 100, 500, 1000, 2000, 5000, 10000, 20000 };
    float[] AtkSpeedTable = { 0.01f, 0.05f, 0.1f, 0.15f, 0.2f, 0.5f, 1f, 1.2f, 1.5f, 2f };

    public Text HpLevelText;
    public Text HpPriceText;
    public Text CurrentHpText;
    public Text HpUpgradeText;
    public Button HpUpgradeButton;

    public Text AttackLevelText;
    public Text AttackPriceText;
    public Text CurrentAttackPowerText;
    public Text AttackPowerUpgradeText;
    public Button AttackUpgradeButton;

    public Text AttackSpeedLevelText;
    public Text AttackSpeedPriceText;
    public Text CurrentAttackSpeedText;
    public Text AttackSpeedUpgradeText;
    public Button AttackSpeedUpgradeButton;

    public Text CoinText;

    bool hpcanbuy = false;
    bool attackcanbuy = false;
    bool attackspeedcanbuy = false;

    void Start()
    {
        CurrentHpText.text = GameManager.Instance.PlayerHp.ToString();
        CurrentAttackPowerText.text = GameManager.Instance.PlayerAtkPower.ToString();
        CurrentAttackSpeedText.text = GameManager.Instance.PlayerAtkSpeed.ToString();
    }

    void Update()  //텍스트 업데이트
    {        
        CoinText.text = GameManager.Instance.coin.ToString();

        if (GameManager.Instance.coin - GameManager.Instance.PlayerHpPrice < 0)
        {
            hpcanbuy = false;
            HpPriceText.color = Color.red;
        }
        else
        {
            hpcanbuy = true;  //체력 구매조건
            HpPriceText.color = Color.green;
        }

        if (GameManager.Instance.coin - GameManager.Instance.PlayerAtkPowerPrice < 0)
        {
            attackcanbuy = false;
            AttackPriceText.color = Color.red;
        }
        else
        {
            attackcanbuy = true;  //공격력 구매조건
            AttackPriceText.color = Color.green;
        }

        if (GameManager.Instance.coin - GameManager.Instance.PlayerAtkSpeedPrice < 0)
        {
            attackspeedcanbuy = false;
            AttackSpeedPriceText.color = Color.red;
        }
        else
        {
            attackspeedcanbuy = true;     //공격속도 구매조건
            AttackSpeedPriceText.color = Color.green;
        }
    }

    public void HpUpgradeBtn()
    {
        if(hpcanbuy)
        {
            int i = GameManager.Instance.PlayerHpLevel / 10;

            if (GameManager.Instance.PlayerHpLevel != GameManager.Instance.MaxUpgradeLevel)
            {
                GameManager.Instance.coin -= GameManager.Instance.PlayerHpPrice;
                GameManager.Instance.PlayerHpLevel++;
                GameManager.Instance.MaxPlayerHp += HpTable[i];
                GameManager.Instance.PlayerHp += HpTable[i];
                GameManager.Instance.PlayerHpPrice += CoinTable[i];
            }

            GameManager.Instance.UpgradeFn
           (GameManager.Instance.PlayerHpLevel, GameManager.Instance.MaxPlayerHp,
               GameManager.Instance.PlayerHpPrice, HpLevelText, CurrentHpText, HpPriceText, HpUpgradeText, HpUpgradeButton, hpcanbuy);

            GameManager.Instance.PlayerHpBar.SetValueMax((int)GameManager.Instance.MaxPlayerHp);
        }
    }

    public void AttackUpgradeBtn()
    {
        if(attackcanbuy)
        {
            int i = GameManager.Instance.PlayerAtkPowerLevel / 10;

            if (GameManager.Instance.PlayerAtkPowerLevel != GameManager.Instance.MaxUpgradeLevel)  //함수에 넣으면 값 저장이 안되기 때문에 따로 작성함
            {
                GameManager.Instance.coin -= GameManager.Instance.PlayerAtkPowerPrice;
                GameManager.Instance.PlayerAtkPowerLevel++;
                GameManager.Instance.PlayerAtkPower += AttackPowerTable[i];
                GameManager.Instance.PlayerAtkPowerPrice += CoinTable[i];
            }

            GameManager.Instance.UpgradeFn
            (GameManager.Instance.PlayerAtkPowerLevel, GameManager.Instance.PlayerAtkPower,
                GameManager.Instance.PlayerAtkPowerPrice, AttackLevelText, CurrentAttackPowerText,
                AttackPriceText, AttackPowerUpgradeText, AttackUpgradeButton, attackcanbuy);
        }
    }

    public void AttackSpeedUpgradeBtn()
    {
        if(attackspeedcanbuy)
        {
            int i = GameManager.Instance.PlayerAtkSpeedLevel / 10;

            if (GameManager.Instance.PlayerAtkSpeedLevel != GameManager.Instance.MaxUpgradeLevel)
            {
                GameManager.Instance.coin -= GameManager.Instance.PlayerAtkSpeedPrice;
                GameManager.Instance.PlayerAtkSpeedLevel++;
                GameManager.Instance.PlayerAtkSpeed += AtkSpeedTable[i];
                GameManager.Instance.PlayerAtkSpeedPrice += CoinTable[i];
            }

            GameManager.Instance.UpgradeFn
           (GameManager.Instance.PlayerAtkSpeedLevel, GameManager.Instance.PlayerAtkSpeed,
               GameManager.Instance.PlayerAtkSpeedPrice, AttackSpeedLevelText, CurrentAttackSpeedText,
               AttackSpeedPriceText, AttackSpeedUpgradeText, AttackSpeedUpgradeButton, attackspeedcanbuy);
            CurrentAttackSpeedText.text = GameManager.Instance.PlayerAtkSpeed.ToString("F2");
        }
    }
}
