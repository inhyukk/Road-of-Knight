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

    public Transform pos;
    public Vector2 boxSize;

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

                //플레이어 피격판정
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    if (collider.tag == "Player")
                    {
                        TakeDamage(GameManager.Instance.EnemyAtkPower);
                    }
                }

        }
    }

    public void TakeDamage(int damage)
    {
        GameManager.Instance.PlayerHp -= damage;
    }
}
