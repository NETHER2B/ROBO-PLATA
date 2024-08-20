using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penDrive : MonoBehaviour
{
    public movimetacaoBasica movP;
    public int MunAtual;

    // Start is called before the first frame update
    void Start()
    {
        MunAtual = movP.municaoatual;
    }

    // Update is called once per frame
    void Update()
    {
        movP = FindObjectOfType(typeof(movimetacaoBasica)) as movimetacaoBasica;
        MunAtual = movP.municaoatual;
        DontDestroyOnLoad(gameObject);
    }
}
