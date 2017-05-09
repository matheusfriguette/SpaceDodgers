using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaRotaciona : MonoBehaviour {

    public float velocidader;
    public float velocidadem;
    public float limite;
    public float retorno;

    void Start () {
		
	}
	
	void Update () {

        transform.Rotate(Vector3.down * Time.deltaTime * velocidader);

        Vector3 velocidadeVetorial = Vector3.left * velocidadem;
        transform.position = transform.position + velocidadeVetorial * Time.deltaTime;

        if (transform.position.x < limite)
        {
            transform.position = new Vector3(retorno, Random.Range(-5, 1.5f), transform.position.z);
        }

    }
}
