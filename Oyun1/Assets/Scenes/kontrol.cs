using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kontrol : MonoBehaviour
{

    public int hiz;
    public float ziplamaKuvveti;
    private float hareketYonu;
    private Rigidbody2D rb;
    private bool karakterSagYuz = true;

    private bool zemin;
    public Transform zeminKontrol;
    public float yaricapKontrol;
    public LayerMask zeminNe;

    private int ekstraZiplama;
    public int ekstraZiplamaSayisi;

    public int can, maxcan;
    public int gem = 0;

    public Animator animator;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

        can = maxcan;


    }

    private void Update()
    {

        if (zemin == true)
        {


            ekstraZiplama = ekstraZiplamaSayisi;

        }


        if (Input.GetKeyDown(KeyCode.Space)&& ekstraZiplama > 0)
        {

            rb.velocity = Vector2.up * ziplamaKuvveti;
            ekstraZiplama--;

        }else if(Input.GetKeyDown(KeyCode.Space) && ekstraZiplama == 0 && zemin == true)
        {
            rb.velocity = Vector2.up * ziplamaKuvveti;
        }

        if(can <= 0)
        {
            olme();
        }

        animator.SetBool("isRunning", Mathf.Abs(rb.velocity.x) > 0.1);
        animator.SetBool("isJumping", !Physics2D.OverlapCircle(zeminKontrol.position, yaricapKontrol, zeminNe));

        
    }

    [System.Obsolete]
    void olme()
    {
        Application.LoadLevel(Application.loadedLevel);
    }


    private void OnTriggerEnter2D(Collider2D nesne)
    {
        if(nesne.gameObject.tag == "gem")
        {
            Destroy(nesne.gameObject);
            gem++;
        }
        if(nesne.gameObject.tag == "Kapi")
        {
            if (gem == 5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }



    private void OnCollisionEnter2D(Collision2D nesne)
    {
        
        if(nesne.gameObject.tag == "Tuzak")
        {
            can -= 1;
            rb.velocity = Vector2.up * ziplamaKuvveti;
            GetComponent<SpriteRenderer> ().color = Color.red;
            Invoke("Duzelt", 0.5f);
        }

    }


    void Duzelt()
    {

        GetComponent<SpriteRenderer>().color = Color.white;

    }


    private void FixedUpdate()
    {

        zemin = Physics2D.OverlapCircle(zeminKontrol.position, yaricapKontrol, zeminNe);

        hareketYonu = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(hareketYonu * hiz, rb.velocity.y);


        if (karakterSagYuz == false && hareketYonu > 0)
        {
            Flip();
        }else if(karakterSagYuz == true && hareketYonu < 0)
        {
            Flip();
        }


    }


    private void Flip()
    {

        karakterSagYuz = !karakterSagYuz;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;


    }



}
