using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public enum MONSTERSTATE
    {
        IDLE = 0,
        ATK,
        DEATH
    }

    static public MONSTERSTATE monsterstate = MONSTERSTATE.IDLE;

    Animator anim;

    public Transform pos;
    public Vector2 boxSize;

    void Awake()
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

                    EnemytoPlayerAttack();

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

                    Destroy(gameObject);

                    break;
                }
        }

        if (GameManager.Instance.EnemyHp <= 0)
        {
            monsterstate = MONSTERSTATE.DEATH;
        }
    }

    private void TakeDamage()
    {
        GameManager.Instance.PlayerHp -= GameManager.Instance.EnemyAtkPower;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

    void EnemytoPlayerAttack()
    {
        //적 피격판정
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Player")
            {
                monsterstate = MONSTERSTATE.ATK;
            }
            else monsterstate = MONSTERSTATE.IDLE;
        }
    }
}
