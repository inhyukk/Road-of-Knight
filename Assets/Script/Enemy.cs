using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum ENEMYSTATE
    {
        IDLE = 0,
        ATK,
        DEATH
    }
    static public ENEMYSTATE enemystate = ENEMYSTATE.IDLE;

    Animator anim;

    public Transform pos;
    public Vector2 boxSize;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        switch (enemystate)
        {
            case ENEMYSTATE.IDLE:
                {
                    anim.SetBool("isIdle", true);
                    anim.SetBool("isAtk", false);
                    anim.SetBool("isDeath", false);

                    EnemytoPlayerAttack();

                    break;
                }
            case ENEMYSTATE.ATK:
                {
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isAtk", true);
                    anim.SetBool("isDeath", false);

                    break;
                }
            case ENEMYSTATE.DEATH:
                {
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isAtk", false);
                    anim.SetBool("isDeath", true);

                    Destroy(gameObject);

                    break;
                }
        }
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
                enemystate = ENEMYSTATE.ATK;
            }
        }
    }

    void TakeDamage()
    {
        GameManager.Instance.PlayerHp -= GameManager.Instance.EnemyAtkPower;
    }
}
