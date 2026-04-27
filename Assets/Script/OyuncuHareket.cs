using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OyuncuHareket : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    Vector2 velocity;

    [SerializeField]
    float hiz = default;

    [SerializeField]
    float hizlanma = default;

    [SerializeField]
    float yavaslama = default;

    [SerializeField]
    float ziplamaGucu = default;

    [SerializeField]
    int ziplamaLimiti = 3;

    int ziplamaSayisi;

    Joystick joystick;

    JoystickButon joystickButon;

    bool zipliyor;

    // Start is called before the first frame update
    void Start()
    {
        joystickButon = FindObjectOfType<JoystickButon>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        
#if UNITY_EDITOR
                KlavyeKontrol();
#else
                JoystickKontrol();
#endif
               
        
    }
    void KlavyeKontrol()
    {
        float haraketinput = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;
        if (haraketinput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, haraketinput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Run", true);
            scale.x = 2;

        }else if (haraketinput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, haraketinput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Run", true);
            scale.x = -2;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Run", false);
        }
        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);




        if (Input.GetKeyDown("space"))
        {
            ZiplamayaBasla();
        }
        if (Input.GetKeyUp("space"))
        {
            ZiplamaDurdur();
        }
    }

    void JoystickKontrol()
    {
        float haraketinput = joystick.Horizontal;

        Vector2 scale = transform.localScale;
        if (haraketinput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, haraketinput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Run", true);
            scale.x = 2;

        }
        else if (haraketinput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, haraketinput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Run", true);
            scale.x = -2;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Run", false);
        }
        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);

        if (joystickButon.tusaBasildi == true && zipliyor == false)
        {
            zipliyor = true;
            ZiplamayaBasla();
        }
        if (joystickButon.tusaBasildi == false && zipliyor == true)
        {
            zipliyor = false;
            ZiplamaDurdur();
        }
    }

    void ZiplamayaBasla()
    {
        if(ziplamaSayisi < ziplamaLimiti)
        {
            rb.AddForce(new Vector2(0, ziplamaGucu), ForceMode2D.Impulse);
            animator.SetBool("jump", true);
            FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti,ziplamaSayisi);
        }
        
    }
    void ZiplamaDurdur()
    {
        animator.SetBool("jump", false);
        ziplamaSayisi++;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);

    }

    public void ZiplamayiSifirla()
    {
        ziplamaSayisi = 0;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "OlumSinir")
        {
            FindObjectOfType<OyunSinirKontrol>().OyunuBitir();
        }
    }
    public void OyunBitti()
    {
        Destroy(gameObject);
    }
}
