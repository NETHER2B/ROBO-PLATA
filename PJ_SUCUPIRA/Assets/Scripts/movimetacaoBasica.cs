using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movimetacaoBasica : MonoBehaviour
{
    private penDrive save;
    
    [Header("Conf Player")]
    public float velocidade;
    private float movimentoHorizontal;
    private Rigidbody2D rbPlayer;
    public float forcaPulo;
    public Transform posicaoSensor;
    public bool sensor;
    private Animator anim;

    //criar uma variável ara verificar a direção 
    public bool verificarDirecaoPersonagem;

    //Configurando tiro
    public GameObject municao;
    public TextMeshProUGUI textMunicao;
    public int municaoatual;
    public Transform posicaoTiro;
    public float velocidadeTiro;


    public int contadorVida;
    public int vidaatual = 10;
    public TextMeshProUGUI Vidaa;
    private bool gameover;
    //public GameObject screamp;


   




    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        save = FindObjectOfType(typeof(penDrive))as penDrive;
        
        municaoatual = save.MunAtual;
    }

    // Update is called once per frame
    void Update()
    {
        verificarChao();
        morte();

        Vidaa.text = vidaatual.ToString();

        textMunicao.text = municaoatual.ToString();




        movimentoHorizontal = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity = new Vector2(movimentoHorizontal*velocidade, rbPlayer.velocity.y);


        //mudar direção do personagem

        if(movimentoHorizontal >0 && verificarDirecaoPersonagem ==true)
        {
            Flip();
        }if(movimentoHorizontal < 0 && verificarDirecaoPersonagem == false)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && sensor==true)
        {
            rbPlayer.AddForce(new Vector2(0, forcaPulo));
        }

        if (Input.GetMouseButtonDown(0) && municaoatual >=1)
        {
            Atirar();
            anim.SetTrigger("tiro");
        }

        anim.SetInteger("Run",(int)movimentoHorizontal);
        anim.SetBool("sensor", sensor);
    }

    public void verificarChao()
    {
        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.34f);
    }
    public void Flip()
    {
        verificarDirecaoPersonagem = !verificarDirecaoPersonagem;

        float x = transform.localScale.x * -1;

        transform.localScale = new Vector3(x, transform.localScale.y,transform.localScale.z);

        velocidadeTiro *= -1;

        municao.GetComponent<SpriteRenderer>().flipX = verificarDirecaoPersonagem;

    }
    public void Atirar()
    {
        GameObject temporario = Instantiate(municao);
        temporario.transform.position = posicaoTiro.position;
        temporario.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeTiro, 0);
        muni();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "vida")
        {
            vidaatual++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "dano")
        {
            vidaatual--;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "recarregar")
        {
            municaoatual  += 5;
            
            Destroy(collision.gameObject);
        }
        if( collision.gameObject.tag =="fase2")
        {
            SceneManager.LoadScene(1);
        }
    }

    private void morte()
    {
        if(vidaatual <= 0)
        {
            gameover = true;
        }
        if(gameover == true)
        {
            Time.timeScale = 0;
            //screamp.SetActive(true);
        }
        else if(gameover == false)
        {
            Time.timeScale = 1;
           //
           //screamp.SetActive(false);
        }
        
    }
    private void muni()
    {
        if(municaoatual != 0)
        {
            municaoatual--;
            
            //GameObject temporario = Instantiate (municao);
        }
    }

}
