using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_P : MonoBehaviour
{
    public float speed;
    public float movHorizontal;
    private Rigidbody2D rbPlayer;
    public float pulo;
    public bool chao;
    public bool sensor;
    public Transform posicaosensor;
    private Animator anim;
    public bool verifdirecao;

    public GameObject municao;
    public Transform posicaoTiro;
    public float speedtiro;



    
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        verificar();
        movHorizontal = Input.GetAxisRaw("Horizontal");
        rbPlayer.velocity = new Vector2(movHorizontal*speed ,rbPlayer.velocity.y);
        if(Input.GetButtonDown("Jump") && sensor== true)
        {
            rbPlayer.AddForce ( new Vector2(0, pulo),ForceMode2D.Impulse);
        }
       
        anim.SetInteger("run",(int)movHorizontal);
        anim.SetBool("jump", sensor);
        
        if(movHorizontal>0 && verifdirecao == true)
        {
            direcao();
            speedtiro *= -1;
        }
        if(movHorizontal<0 && verifdirecao == false)
        {
            direcao();
            speedtiro *= -1;
        }
        if(Input.GetMouseButtonDown(0))
        {
            atira();
            
        }
    }

    public void verificar()
    {
        sensor = Physics2D.OverlapCircle(posicaosensor.position, 0.2f);
    }
    public void direcao()
    {
      verifdirecao = !verifdirecao;
        float x = transform.localScale.x * -1;
        
        transform.localScale = new Vector3(x, transform.localScale.y,transform.localScale. z);
        municao.GetComponent<SpriteRenderer>().flipX = verifdirecao;
    }
    public void atira()
    {
        GameObject temp = Instantiate(municao);
        temp.transform.position = posicaoTiro.position;
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(speedtiro, 0);
        anim.SetTrigger("shoot");
    }
}
