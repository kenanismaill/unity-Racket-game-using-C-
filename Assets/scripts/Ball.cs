using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public AudioSource audios;
    // Start is called before the first frame update
    private void Awake()
    {
    }
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f); // herer you can change  the value 2f to another to make sure if it starts after x seconds  
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1, 0) * 20;
        audios = this.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // GetComponent<AudioSource>().Play(); doesnt work i couldnt find reason :)
        audios.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
