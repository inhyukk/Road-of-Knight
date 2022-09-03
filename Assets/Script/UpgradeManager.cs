using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    int[] GoldTable = { 10, 50, 100, 200, 300 };
    int[] AttackPowerTable = { 1, 2, 5, 10, 20 };
    int[] HpTable = { 100, 200, 500, 1000, 2000 };
    float[] AtkSpeedTable = { 0.01f, 0.02f, 0.05f, 0.1f, 0.15f };

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

    public void HpUpgradeBtn()
    {
        int i = GameManager.Instance.PlayerHpLevel / 10;

        if (GameManager.Instance.PlayerHpLevel != GameManager.Instance.MaxUpgradeLevel)
        {
            if (GameManager.Instance.coin >= GoldTable[i])
            {
                GameManager.Instance.coin -= GameManager.Instance.PlayerHpPrice;
                GameManager.Instance.PlayerHpLevel++;
                GameManager.Instance.MaxPlayerHp += HpTable[i];
                GameManager.Instance.PlayerHpPrice += GoldTable[i];

                HpLevelText.text = GameManager.Instance.PlayerHpLevel.ToString() + " Lv";
                HpPriceText.text = GameManager.Instance.PlayerHpPrice.ToString() + "G";
                CurrentHpText.text = GameManager.Instance.MaxPlayerHp.ToString();

                //Debug.Log("Atk Level : " + GameManager.Instance.CurrentPlayerAtkLevel + "Lv");

                if (GameManager.Instance.PlayerHpLevel == GameManager.Instance.MaxUpgradeLevel)
                {
                    HpLevelText.text = "Max Lv";
                    HpPriceText.enabled = false;
                    HpUpgradeButton.GetComponent<Button>().enabled = false;

                    //Debug.Log("더 이상 강화하실 수 없습니다.");
                }
            }
            else
            {
                //알림 띄우기

                //Debug.Log("돈이 부족하여 구매하실 수 없습니다.");
            }
        }
    }

    public void AttackUpgradeBtn()
    {
        int i = GameManager.Instance.PlayerAtkLevel / 10;

        if(GameManager.Instance.PlayerAtkLevel != GameManager.Instance.MaxUpgradeLevel)
        {
            if(GameManager.Instance.coin >= GoldTable[i])
            {
                GameManager.Instance.coin -= GameManager.Instance.PlayerAtkPrice;
                GameManager.Instance.PlayerAtkLevel++;
                GameManager.Instance.PlayerAtkPower += AttackPowerTable[i];
                GameManager.Instance.PlayerAtkPrice += GoldTable[i];

                AttackLevelText.text = GameManager.Instance.PlayerAtkLevel.ToString() + " Lv";
                AttackPriceText.text = GameManager.Instance.PlayerAtkPrice.ToString() + "G";
                CurrentAttackText.text = GameManager.Instance.PlayerAtkPower.ToString();

                //Debug.Log("Atk Level : " + GameManager.Instance.CurrentPlayerAtkLevel + "Lv");

                if (GameManager.Instance.PlayerAtkLevel == GameManager.Instance.MaxUpgradeLevel)
                {
                    AttackLevelText.text = "Max Lv";
                    AttackPriceText.enabled = false;
                    AttackUpgradeButton.GetComponent<Button>().enabled = false;

                    //Debug.Log("더 이상 강화하실 수 없습니다.");
                }
            }
            else
            {
                //알림 띄우기

                //Debug.Log("돈이 부족하여 구매하실 수 없습니다.");
            }
        }
    }

    public void AttackSpeedUpgradeBtn()
    {
        int i = GameManager.Instance.PlayerAtkSpeedLevel / 10;

        if (GameManager.Instance.PlayerAtkSpeedLevel != GameManager.Instance.MaxUpgradeLevel)
        {
            if (GameManager.Instance.coin >= GoldTable[i])
            {
                GameManager.Instance.coin -= GameManager.Instance.PlayerAtkSpeedPrice;
                GameManager.Instance.PlayerAtkSpeedLevel++;
                GameManager.Instance.PlayerAtkSpeed += AtkSpeedTable[i];
                GameManager.Instance.PlayerAtkSpeedPrice += GoldTable[i];

                AttackSpeedLevelText.text = GameManager.Instance.PlayerAtkSpeedLevel.ToString() + " Lv";
                AttackSpeedPriceText.text = GameManager.Instance.PlayerAtkSpeedPrice.ToString() + "G";
                CurrentAttackSpeedText.text = GameManager.Instance.PlayerAtkSpeed.ToString();

                //Debug.Log("Atk Level : " + GameManager.Instance.CurrentPlayerAtkLevel + "Lv");

                if (GameManager.Instance.PlayerAtkSpeedLevel == GameManager.Instance.MaxUpgradeLevel)
                {
                    AttackSpeedLevelText.text = "Max Lv";
                    AttackSpeedPriceText.enabled = false;
                    AttackSpeedUpgradeButton.GetComponent<Button>().enabled = false;

                    //Debug.Log("더 이상 강화하실 수 없습니다.");
                }
            }
            else
            {
                //알림 띄우기

                //Debug.Log("돈이 부족하여 구매하실 수 없습니다.");
            }
        }
    }

    private void Update()
    {
        CoinText.text = GameManager.Instance.coin.ToString();
    }
}
