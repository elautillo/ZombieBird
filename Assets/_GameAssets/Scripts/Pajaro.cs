using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pajaro : MonoBehaviour {

    [SerializeField] Text marcador;
    [SerializeField] ParticleSystem sangre;
    [SerializeField] float impulso;
    [SerializeField] AudioSource sonidoGolpe;
    [SerializeField] AudioSource sonidoPunto;
    [SerializeField] AudioSource sonidoAla;

    Rigidbody rb;
    int puntos;

    void Start ()
    {
        impulso = 300f;
        puntos = 0;
        rb = GetComponent<Rigidbody>();
        marcador.text = "Score: " + puntos;
    }

	void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            sonidoAla.Play();
            rb.AddForce(transform.up * impulso);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        //Generamos sonido
        sonidoPunto.Play();

        //Conteamos puntos
        puntos++;
        marcador.text = "Score: " + puntos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Generamos sonido
        sonidoGolpe.Play();

        //Detenemos juego
        GameConfig.Stop();

        //Instanciamos partículas
        Instantiate(sangre, transform.position, Quaternion.identity);

        //Desactivamos pájaro
        gameObject.SetActive(false);

        //Finalizamos partida
        Invoke("FinalizarPartida", 0.5f);
    }

    private void FinalizarPartida()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(0);
        GameConfig.Play();
    }
}
