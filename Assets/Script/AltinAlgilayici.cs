using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltinAlgilayici : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ayaklar")
        {
            GetComponentInParent<Altin>().AltinKapat();
            FindObjectOfType<Puan>().AltinKazan();
        }
    }
}
