using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public enum MONSTERSTATE
    {
        IDLE = 0,
        ATK,
        DAMAGE,
        DEATH
    }

    static public MONSTERSTATE monsterstate = MONSTERSTATE.IDLE;

    Animator anim;

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        switch (monsterstate)
        {
            case MONSTERSTATE.IDLE:
                {
                    anim.SetBool("isIdle", true);
                    anim.SetBool("isAtk", false);
                    anim.SetBool("isDeath", false);

                    break;
                }
            case MONSTERSTATE.ATK:
                {
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isAtk", true);
                    anim.SetBool("isDeath", false);

                    break;
                }
            case MONSTERSTATE.DEATH:
                {
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isAtk", false);
                    anim.SetBool("isDeath", true);

                    break;
                }

        }
    }

    public void TakeDamage(int damage)
    {
        GameManager.Instance.EnemyHp -= damage;
    }
}
