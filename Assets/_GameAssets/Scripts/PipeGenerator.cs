using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour {

    [SerializeField] Transform tuberias;

    void Start ()
    {
        InvokeRepeating("GeneratePipe", 0, 3);
    }

	void Update ()
    {
		
	}

    void GeneratePipe ()
    {
        if (GameConfig.IsPlaying())
        {
            Instantiate(tuberias, transform.position, Quaternion.identity);
        }
    }
}
