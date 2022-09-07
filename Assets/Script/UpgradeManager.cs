using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    int[] GoldTable = { 10, 50, 100, 200, 300 };
    int[] AttackPowerTable = { 1, 2, 5, 10, 20 };
    int[] HpTable = { 100, 200, 500, 1000, 2000 };
    float[] AtkSpeedTable = { 0.01f, 0.05f, 0.1f, 0.15f, 0.2f };

    public Text HpLevelText;
    public Text HpPriceText;
    public Text CurrentHpText;
    public Button HpUpgradeButton;

    public Text AttackLevelText;
    public Text AttackPriceText;
    public Text CurrentAttackText;
    public Button AttackUpgradeButton;

    public Text AttackSpeedLevelText;
    public Text AttackSpeedPriceText;
    public Text CurrentAttackSpeedText;
    public Button AttackSpeedUpgradeButton;

    public Text CoinText;

    private void Start()
    {
        StartCoroutine(UIUpdate());
    }

    IEnumerator UIUpdate()
    {
        while (true)
        {
            CoinText.text = GameManager.Instance.coin.ToString();

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void HpUpgradeBtn()
    {
        int i = GameManager.Instance.PlayerHpLevel / 10;

        if (GameManager.Instance.PlayerHpLevel != GameManager.Instance.MaxUpgradeLevel)
        {
            GameManager.Instance.coin -= GameManager.Instance.PlayerHpPrice;
            GameManager.Instance.PlayerHpLevel++;
            GameManager.Instance.MaxPlayerHp += HpTable[i];
            GameManager.Instance.PlayerHpPrice += GoldTable[i];
        }

        GameManager.Instance.UpgradeFn
        (GameManager.Instance.PlayerHpLevel, GameManager.Instance.PlayerHp,
            GameManager.Instance.PlayerHpPrice, HpLevelText, CurrentHpText, HpPriceText, HpUpgradeButton);
    }

    public void AttackUpgradeBtn()
    {
        int i = GameManager.Instance.PlayerAtkLevel / 10;

        if (GameManager.Instance.PlayerAtkLevel != GameManager.Instance.MaxUpgradeLevel)  //여기도 함수에 넣으면 값이 안바뀌기 때문에 따로 작성함
        {
            GameManager.Instance.coin -= GameManager.Instance.PlayerAtkPrice;
            GameManager.Instance.PlayerAtkLevel++;
            GameManager.Instance.PlayerAtkPower += AttackPowerTable[i];
            GameManager.Instance.PlayerAtkPrice += GoldTable[i];
        }

        GameManager.Instance.UpgradeFn
        (GameManager.Instance.PlayerAtkLevel, GameManager.Instance.PlayerAtkPower,
            GameManager.Instance.PlayerAtkPrice, AttackLevelText, CurrentAttackText, AttackPriceText, AttackUpgradeButton);        
    }

    public void AttackSpeedUpgradeBtn()
    {
        int i = GameManager.Instance.PlayerAtkLevel / 10;

        if (GameManager.Instance.PlayerAtkSpeedLevel != GameManager.Instance.MaxUpgradeLevel)
        {
            GameManager.Instance.coin -= GameManager.Instance.PlayerAtkSpeedPrice;
            GameManager.Instance.PlayerAtkSpeedLevel++;
            GameManager.Instance.PlayerAtkSpeed += AtkSpeedTable[i];
            GameManager.Instance.PlayerAtkSpeedPrice += GoldTable[i];
        }

        GameManager.Instance.UpgradeFn
        (GameManager.Instance.PlayerAtkSpeedLevel, GameManager.Instance.PlayerAtkSpeed,
            GameManager.Instance.PlayerAtkSpeedPrice, AttackSpeedLevelText, CurrentAttackSpeedText, AttackSpeedPriceText, AttackSpeedUpgradeButton);
    }
}
