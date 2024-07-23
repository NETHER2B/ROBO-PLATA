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
    }

    public void verificar()
    {
        sensor = Physics2D.OverlapCircle(posicaosensor.position, 0.34f);
    }
}
