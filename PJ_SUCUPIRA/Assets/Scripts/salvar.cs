using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salvar : MonoBehaviour
{
    public float muni;
    private movimetacaoBasica movimetacao;
    // Start is called before the first frame update
    void Start()
    {
        movimetacao = FindObjectOfType(typeof( movimetacaoBasica )) as movimetacaoBasica;
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
        muni = movimetacao.municaoatual;
    }
}
