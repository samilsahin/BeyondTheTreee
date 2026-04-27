using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunSinirKontrol : MonoBehaviour
{

    public GameObject oyunBittiPanel;
    public GameObject joystick;
    public GameObject ziplamaButonu;
    public GameObject tabela;
    public GameObject anaMenuButonu;
    public GameObject slider;


    // Start is called before the first frame update
    void Start()
    {
        oyunBittiPanel.SetActive(false);
        UIAc();
    }


    public void OyunuBitir()
    {
        oyunBittiPanel.SetActive(true);
        FindObjectOfType<Puan>().OyunBitti();
        FindObjectOfType<OyuncuHareket>().OyunBitti();
        UIKapat();
    }
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("Menu");
    }
    public void TekrarOyna()
    {
        SceneManager.LoadScene("Oyun");
    }
    void UIAc()
    {
        joystick.SetActive(true);
        ziplamaButonu.SetActive(true);
        tabela.SetActive(true);
        anaMenuButonu.SetActive(true);
        slider.SetActive(true);
        
    }
    void UIKapat()
    {
        joystick.SetActive(false);
        ziplamaButonu.SetActive(false);
        tabela.SetActive(false);
        anaMenuButonu.SetActive(false);
        slider.SetActive(false);
    }
}
