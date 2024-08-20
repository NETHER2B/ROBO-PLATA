using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    public Transform[] PosDes;
    public float dis1,dis2,direcao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector2(direcao*transform.localScale.x,transform.localScale.y);
        verifyDis();
    }
    void verifyDis()
    {
        dis1 = Vector3.Distance(transform.position, PosDes[0].position);
        dis2 = Vector3.Distance(transform.position, PosDes[1].position);
        if(dis1 <= 1)
        {
            direcao = -1;
            
        }else if(dis2 <= 1)
        {
            direcao = 1;
        }
        transform.Translate(Vector2.right*direcao*speed*Time.deltaTime);
    }
}
