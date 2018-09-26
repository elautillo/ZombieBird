using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour {

    [SerializeField] Transform tuberias;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("GeneratePipe", 0, 3);
    }
	
	// Update is called once per frame
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
