using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour
{
    private AudioSource source;
    public GameObject fonografo;
    // Start is called before the first frame update
    void Start()
    {
        fonografo=GameObject.Find("phonograph");
        source = fonografo.GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Fire") {
			source.Stop();
		}
	}
}
