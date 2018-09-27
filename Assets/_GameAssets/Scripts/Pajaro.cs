using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pajaro : MonoBehaviour {

    [SerializeField] Text marcador;
    [SerializeField] ParticleSystem sangre;
    [SerializeField] float fuerza = 300f;
    AudioSource audioSource;
    Rigidbody rb;
    int puntos = 0;

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        marcador.text = "Score: " + puntos;
    }

	void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(transform.up * fuerza);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        puntos++;
        Debug.Log(puntos.ToString());
        marcador.text = "Score: " + puntos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //DETENEMOS EL JUEGO
        GameConfig.Stop();

        //INSTANCIAR SISTEMA DE PARTICULAS
        Instantiate(sangre, transform.position, Quaternion.identity);

        //DESACTIVAR EL RENDERER DEL PAJARO
        gameObject.SetActive(false);

        //FINALIZAMOS LA PARTIDA TRAS UN DELAY
        Invoke("FinalizarPartida", 0.5f);
    }

    private void FinalizarPartida()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(0);
        GameConfig.Play();
    }
}
