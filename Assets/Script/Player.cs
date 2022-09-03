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

    private void Start()
    {
        animSpeed = GameManager.Instance.PlayerAtkSpeed;
    }

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
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isRun", false);
                    anim.SetBool("isAtk", true);
                    anim.SetFloat("AtkSpeed", animSpeed);

                    break;
                }
        }

        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach(Collider2D collider in collider2Ds)
        {
            if(collider.tag == "Enemy")
            {
                collider.GetComponent<Monster>().TakeDamage(GameManager.Instance.PlayerAtkPower);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}
