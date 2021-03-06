﻿using UnityEngine;

public class PlanetaMove : MonoBehaviour
{

    public float velocidade;
    public float limite;
    public float retorno;

    void Start()
    {

    }

    void Update()
    {

        Vector3 velocidadeVetorial = Vector3.left * velocidade;
        transform.position = transform.position + velocidadeVetorial * Time.deltaTime;

        if (transform.position.x < limite)
        {
            transform.position = new Vector3(retorno, Random.Range(-3, 3f), transform.position.z);
        }
    }
}
