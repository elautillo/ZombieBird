using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuberias : MonoBehaviour {

    [SerializeField] int speed = 3;

	// Use this for initialization
	void Start ()
    {
        float factorPosicion = Random.Range(-4, 4);
        transform.position = new Vector3
            (
            transform.position.x,
            transform.position.y + factorPosicion,
            transform.position.z
            );
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameConfig.IsPlaying())
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if (transform.position.x < -8)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
