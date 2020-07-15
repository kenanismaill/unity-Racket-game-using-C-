using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

    string AxisDirection = "Horizontal";
    float playerspeed = 15;
    public Transform fireball;
    public GameObject bombaprefab;
    public Text Score;
    public GameObject top;
    public GameData gamedata;
    public bool yeniOyun = false;

    private float zaman = 0;
    
    private void Start()
    {
        
        if (yeniOyun)
        {
            gamedata = new GameData(top.transform.position.x, transform.position.x, transform.position.y, 0);
            SaveLoadManager.Save("ver.txt", gamedata);

        }
        //previous data info 
        else
        {
            gamedata = SaveLoadManager.Load("ver.txt");
        }
        
        yerlestir();
        Score.text = gamedata.skor.ToString();
    }

    public void yerlestir()
    {
        //find postions of ball and player in previous game 
        
         
        top.transform.position = new Vector3(gamedata.top, top.transform.position.y);
        Vector3 oyuncuPos = new Vector3(gamedata.oyuncuXpos, gamedata.oyuncuYpos);
        transform.position = oyuncuPos;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float AxisMoved = Input.GetAxis(AxisDirection) * playerspeed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(AxisMoved, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            throwfireball();
        }

        if (zaman <= 0)
        {
            if(top.transform.position.y - transform.position.y <= 0.5f)
            {
                Vector3 oyuncuPos = new Vector3(gamedata.oyuncuXpos, -4f);
                transform.position = oyuncuPos;
                gamedata.top = top.transform.position.x;
                gamedata.oyuncuXpos = transform.position.x;
                gamedata.oyuncuYpos = transform.position.y;
                SaveLoadManager.Save("ver.txt", gamedata);
                SceneManager.LoadScene(1);
            }
            gamedata.top = top.transform.position.x;
            gamedata.oyuncuXpos = transform.position.x;
            gamedata.oyuncuYpos = transform.position.y;

            SaveLoadManager.Save("ver.txt", gamedata);
            zaman = 0.1f;
        }
        else
            zaman -= Time.deltaTime;
    }

    private void throwfireball()
    {
        GameObject temp = Instantiate(bombaprefab, fireball.position, fireball.rotation) as GameObject;
        Destroy(temp, 2f);
    }
    public void makeScore()
    {
        gamedata.skor++;
        SaveLoadManager.Save("ver.txt", gamedata);
        Score.text = gamedata.skor.ToString();
       
    }
}
