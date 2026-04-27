using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlumculPlatform : MonoBehaviour
{
    BoxCollider2D boxC2D;

    bool hareket;
    float randomHiz;

    float min, max;

    public bool Hareket
    {
        get
        {
            return hareket;
        }
        set
        {
            hareket = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        boxC2D = GetComponent<BoxCollider2D>();

        randomHiz = Random.Range(0.5f, 1.0f);
        float objeGenislik = boxC2D.bounds.size.x / 2;

        if (transform.position.x > 0)
        {
            min = objeGenislik;
            max = EkranHesaplayici.instance.Genislik - objeGenislik;
        }
        else
        {
            min = -EkranHesaplayici.instance.Genislik + objeGenislik;
            max = -objeGenislik;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hareket)
        {
            float pingpongX = Mathf.PingPong(Time.time * randomHiz, max - min) + min;
            Vector2 pingpong = new Vector2(pingpongX, transform.position.y);
            transform.position = pingpong;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ayaklar")
        {
            FindObjectOfType<OyunSinirKontrol>().OyunuBitir();
        }       
    }
}
