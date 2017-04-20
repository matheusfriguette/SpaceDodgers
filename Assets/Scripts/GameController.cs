using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Estado estado { get; private set; }
    public Text txtPontos;
    private int pontos;
    public GameObject obstaculo;
    public float espera;
    public float tempoDestruicao;
    public GameObject menu;
    public GameObject painelMenu;

    public static GameController instancia = null;
    private void Awake() {
        if (instancia == null) {
            instancia = this;
        }
        else if (instancia != null) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        estado = Estado.AguardandoComecar;
	}
	

	IEnumerator GerarObstaculos() {
        while (GameController.instancia.estado == Estado.Jogando) {
            Vector3 pos = new Vector3(6.5f, Random.Range(-3f, 3f), 3.18f);
            GameObject obj = Instantiate(obstaculo, pos, Quaternion.identity) as GameObject;
            Destroy(obj, tempoDestruicao);  
            yield return new WaitForSeconds(espera);
        }
    }

    public void PlayerComecou() {
        estado = Estado.Jogando;
        menu.SetActive(false);
        painelMenu.SetActive(false);
        atualizarPontos(0);
        StartCoroutine(GerarObstaculos());
    }

    public void PlayerMorreu() {
        estado = Estado.GameOver;
    }

    private void atualizarPontos(int x)
    {
        pontos = x;
        txtPontos.text = "" + x;
    }

}
