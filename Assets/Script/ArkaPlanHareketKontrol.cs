using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanHareketKontrol : MonoBehaviour
{
    float arkaPlanKontrol;
    float mesafe = 12.8f;
    // Start is called before the first frame update
    void Start()
    {
        arkaPlanKontrol = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(arkaPlanKontrol+ mesafe < Camera.main.transform.position.y)
        {
            ArkaPlanYerleþtir();
        }
    }

    void ArkaPlanYerleþtir()
    {
        arkaPlanKontrol += (mesafe * 2);
        Vector2 yeniPozisyon = new Vector2(0, arkaPlanKontrol);
        transform.position = yeniPozisyon;
    }
}
