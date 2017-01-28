using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {
    private float zDir = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, 0, zDir) * Time.deltaTime;

        if (transform.position.z > 4.8f || transform.position.z < -1) {
            zDir *= -1;
        }
	}
}
