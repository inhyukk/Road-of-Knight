using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

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

    [HideInInspector] public float animSpeed = 0;

    public Animator anim;
    public Transform pos;
    public Vector2 boxSize = new Vector2(1.5f, 1.5f);

    public Canvas MenuCanvas;

    void Start()
    {
        MenuCanvas.enabled = false;
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
                    anim.SetBool("isDeath", false);

                    break;
                }
            case PLAYERSTATE.RUN:
                {
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isRun", true);
                    anim.SetBool("isAtk", false);
                    anim.SetBool("isDeath", false);

                    gameObject.transform.position =
                            Vector3.MoveTowards(gameObject.transform.position, new Vector3(4.5f, 1.32f, 0), 0.05f);
                    PlayertoEnemyAttack();

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

    void PlayertoEnemyAttack()   //애니메이션 이벤트
    {
        //적 피격판정
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Enemy")  playerstate = PLAYERSTATE.ATK;            
            else playerstate = PLAYERSTATE.RUN;            
        }
    }

    private void GiveDamage()
    {
        GameManager.Instance.EnemyHp -= GameManager.Instance.PlayerAtkPower;
        GameManager.Instance.sfx[2].PlayOneShot(GameManager.Instance.sfx[2].clip);
        GameManager.Instance.sfx[3].PlayDelayed(0.05f);
    }

    void StopStep()
    {
        GameManager.Instance.sfx[4].Stop();
    }

    void GameOver()
    {
        GameManager.Instance.sfx[0].Stop();
        GameManager.Instance.sfx[2].Stop();
        GameManager.Instance.sfx[3].Stop();
        GameManager.Instance.sfx[4].Stop();
        GameManager.Instance.sfx[1].Play();
        Invoke("MenuOn", GameManager.Instance.sfx[1].clip.length);
    }

    void MenuOn()
    {
        MenuCanvas.enabled = true;
        Time.timeScale = 0;
    }
}