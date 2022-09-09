using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static Monster;

public class Player : MonoBehaviour
{
    public enum PLAYERSTATE
    {
        IDLE = 0,
        RUN,
        ATK,
        DEATH
    }
    static public PLAYERSTATE playerstate = PLAYERSTATE.RUN;

    public float animSpeed = 0;

    public Animator anim;

    public Transform pos;
    public Vector2 boxSize;

    bool isAtk = false;

    void Update()
    {
        switch (playerstate)
        {
            case PLAYERSTATE.IDLE:
                {
                    anim.SetBool("isIdle", true);
                    anim.SetBool("isRun", false);
                    anim.SetBool("isAtk", false);
                    anim.SetBool("isDeath", false);

                    break;
                }
            case PLAYERSTATE.RUN:
                {
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isRun", true);
                    anim.SetBool("isAtk", false);
                    anim.SetBool("isDeath", false);

                    break;
                }
            case PLAYERSTATE.ATK:
                {
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isRun", false);
                    anim.SetBool("isAtk", true);
                    anim.SetBool("isDeath", false);

                    animSpeed = GameManager.Instance.PlayerAtkSpeed;
                    anim.SetFloat("AtkSpeed", animSpeed);

                    break;
                }
            case PLAYERSTATE.DEATH:
                {
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isRun", false);
                    anim.SetBool("isAtk", false);
                    anim.SetBool("isDeath", true);
                    break;
                }
        }

        
    }

    private void GiveDamage(float damage)
    {
        GameManager.Instance.EnemyHp -= damage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

    IEnumerator PlayertoEnemyAttack()
    {
        //적 피격판정
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Enemy")
            {
                GiveDamage(GameManager.Instance.PlayerAtkPower);
            }
        }

        yield return new WaitForSeconds(0.1f);
    }
}
