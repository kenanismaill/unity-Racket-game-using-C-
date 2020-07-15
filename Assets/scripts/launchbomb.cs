using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchbomb : MonoBehaviour
{
    public PlayerControl playercontroller;
    public float speed = 10f;
    public Rigidbody2D rb2;
    // Start is called before the first frame update
    void Start()
    {
        playercontroller = FindObjectOfType<PlayerControl>();
        rb2.velocity = transform.up*speed;  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.name == "Ball")
        {
            playercontroller.makeScore();
            Destroy(gameObject);
            if (playercontroller.gamedata.skor % 5 ==0)
            {
                playercontroller.transform.position = new Vector2(playercontroller.transform.position.x, playercontroller.transform.position.y + 1);
            }

        }
    }
}
