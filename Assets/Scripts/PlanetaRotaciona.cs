using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaRotaciona : MonoBehaviour {

    public float velocidader;

	void Start () {
		
	}
	
	void Update () {

        transform.Rotate(Vector3.down * Time.deltaTime * velocidader);

    }
}
