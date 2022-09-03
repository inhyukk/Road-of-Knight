using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Player : MonoBehaviour
{
    public enum PLAYERSTATE
    {
        IDLE = 0,
        RUN,
        ATK,
    }
    static public PLAYERSTATE playerstate = PLAYERSTATE.RUN;

    public float animSpeed = 0;

    public Animator anim;

    public Transform pos;
    public Vector2 boxSize;

    void Update()
    {
        switch (playerstate)
        {
            case PLAYERSTATE.IDLE:
                {
                    anim.SetBool("isIdle", true);
                    anim.SetBool("isRun", false);
                    anim.SetBool("isAtk", false);

                    break;
                }
            case PLAYERSTATE.RUN:
                {
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isRun", true);
                    anim.SetBool("isAtk", false);

                    

                    break;
                }
            case PLAYERSTATE.ATK:
                {
                    animSpeed = GameManager.Instance.PlayerAtkSpeed;

                    anim.SetBool("isIdle", false);
                    anim.SetBool("isRun", false);
                    anim.SetBool("isAtk", true);
                    anim.SetFloat("AtkSpeed", animSpeed);

                    break;
                }
        }

        //적 피격판정
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach(Collider2D collider in collider2Ds)
        {
            if(collider.tag == "Enemy")
            {
                GiveDamage(GameManager.Instance.PlayerAtkPower);
            }
        }
    }

    public void GiveDamage(int damage)
    {
        GameManager.Instance.EnemyHp -= damage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}
