using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perse : MonoBehaviour
{

    public Transform target; // O objeto que deve ser seguido
    public float followDistance = 4f; // Distância acima do alvo
    private bool isFollowing = false; // Flag para verificar se está seguindo

    void Update()
    {
        if (isFollowing && target != null)
        {
            // Atualiza a posição do objeto que segue
            transform.position = target.position + new Vector3(0, followDistance, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto colidido é o alvo
        if (other.transform == target)
        {
            isFollowing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto saiu do raio do colisor
        if (other.transform == target)
        {
            isFollowing = false;
        }
    }
}
