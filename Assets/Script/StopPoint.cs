using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPoint : MonoBehaviour
{
    float movedist = 4.5f;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        player.gameObject.transform.position =
                            Vector3.MoveTowards(player.gameObject.transform.position, new Vector3(movedist, 1.32f, 0), 0.02f);

        gameObject.transform.position = new Vector3(movedist + 0.4f, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);

            Player.playerstate = Player.PLAYERSTATE.ATK;
        }
    }
}
