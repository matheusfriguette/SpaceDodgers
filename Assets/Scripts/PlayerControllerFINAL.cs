using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFINAL : MonoBehaviour {

    public float ForcaDoPulo = 10f;
    public AudioClip somPulo;
    public AudioClip somMorte;
    private bool rotating = true;
    private Animator anim;
    private Rigidbody rb;
    private AudioSource audioSource;
    private bool pulando = false;
    private Vector3 posicaoInicial;
    private Quaternion rotacaoInicial;

    void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
    }

    void Update() {
        if (GameController.instancia.estado == Estado.Jogando) {
            if (Input.GetMouseButton(0)) {
                audioSource.PlayOneShot(somPulo);
                var rotation = Quaternion.Euler(-15, 90, 0);
                transform.rotation = rotation;
                rb.useGravity = true;
                pulando = true;
            }

        }

    }

    void FixedUpdate() {
        if (GameController.instancia.estado == Estado.Jogando) {
            if (pulando) {
                pulando = false;
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * ForcaDoPulo, ForceMode.Impulse);
                var rotation = Quaternion.Euler(0, 90, 0);
                transform.rotation = rotation;
                var rotation2 = Quaternion.Euler(0, 90, 0);
                transform.rotation = rotation2;
            }

        }
    }

    void OnCollisionEnter(Collision outro) {
        if (GameController.instancia.estado == Estado.Jogando) {
            if (outro.gameObject.tag == "obstaculo") {
                rb.AddForce(new Vector3(-50f, 20f, 0f), ForceMode.Impulse);
                rb.detectCollisions = false;
                anim.Play("morrendo");
                audioSource.PlayOneShot(somMorte);
                GameController.instancia.PlayerMorreu();
            }
        }
    }

    public void recomecar()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.detectCollisions = true;
        transform.localPosition = posicaoInicial;
        transform.localRotation = rotacaoInicial;
    }

    

}
