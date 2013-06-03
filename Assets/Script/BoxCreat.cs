using UnityEngine;
using System.Collections;

public class BoxCreat : MonoBehaviour {
    public GameObject Box;
    public bool BoxOn = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (BoxOn == true) {
            Instantiate(Box, this.transform.position, Box.transform.rotation);
            BoxOn = false;
        }
	}
}
