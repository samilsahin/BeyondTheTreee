using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour

{
    [SerializeField]
    GameObject platformPrefab = default;

    [SerializeField]
    GameObject olumculPlatformPrefab = default;

    [SerializeField]
    GameObject playerPrefab = default;

    List<GameObject> platforms = new List<GameObject> ();

    Vector2 platformPozisyon;
    Vector2 playerPozisyon;

    [SerializeField]
    float platformArasiMesafe = default;
    // Start is called before the first frame update
    void Start()
    {
        PlatformUret();
    }

    // Update is called once per frame
    void Update()
    {
        if (platforms[platforms.Count - 1 ].transform.position.y < 
            Camera.main.transform.position.y + EkranHesaplayici.instance.Yukseklik) 
        {
            PlatformYerlestir();
        }
    }
    void PlatformUret()
    {
        platformPozisyon = new Vector2(0, 0);
        playerPozisyon = new Vector2(0, 0.5f);

        GameObject player = Instantiate(playerPrefab,playerPozisyon,Quaternion.identity);
        GameObject ilkPlatform = Instantiate(platformPrefab, platformPozisyon, Quaternion.identity);
        player.transform.parent = ilkPlatform.transform;
        platforms.Add(ilkPlatform);
        SonrakiPozisyon();
        ilkPlatform.GetComponent<Platform>().Hareket = false;


        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab,platformPozisyon,Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().Hareket = true;
            if (i % 2 == 0)
            {
                platform.GetComponent<Altin>().AltinAc();
            }
            SonrakiPozisyon();
        }

        GameObject olumculPlatform = Instantiate(olumculPlatformPrefab, platformPozisyon, Quaternion.identity);
        olumculPlatform.GetComponent<OlumculPlatform>().Hareket = true;
        platforms.Add(olumculPlatform);

        SonrakiPozisyon();
    }

    void PlatformYerlestir()
    {
        for (int i = 0;i < 5; i++)
        {
            GameObject temp;
            temp = platforms[i+5];
            platforms[i+5] = platforms[i];
            platforms[i] = temp;
            platforms[i+5].transform.position = platformPozisyon;
            if(platforms[i + 5].gameObject.tag == "Platform")
            {
                platforms[i + 5].GetComponent<Altin>().AltinKapat();
                float rastGelenAltin = Random.Range(0.0f , 1.0f );
                if(rastGelenAltin > 0.5f)
                {
                    platforms[i + 5].GetComponent<Altin>().AltinAc();
                }
            }
            SonrakiPozisyon();
        }
    }
    void SonrakiPozisyon()
    {
        platformPozisyon.y += 3.0f;
        float random = Random.Range(0.0f, 1.0f);

        if (random < 0.5f)
        {
            platformPozisyon.x = EkranHesaplayici.instance.Genislik / 2;

        }else
        {
            platformPozisyon.x = -EkranHesaplayici.instance.Genislik / 2;

        }
    }
}
