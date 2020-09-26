using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	private Rigidbody rgb;
	private SphereCollider col;
	private Material m;
	public GameObject bola;

	// Use this for initialization
	void Start () {
		rgb = GetComponent<Rigidbody> ();
		col = GetComponent<SphereCollider> ();
		m = GetComponent<Renderer>().material;
		//generadorRampa = GameObject.Find ("GeneradorRampa");
		bola=GameObject.Find("ball");
	}

	// Update is called once per frame
	void Update () {
		/* if (floatingToGeneradorRampa) {
			float t = (Time.time - tIni) / tDespuesOlla;
			if (t < 1f) {
				Vector3 p = Vector3.Lerp (pIni, generadorRampa.transform.position, t);
				transform.position = p;
			} else {
				floatingToGeneradorRampa = false;
				MakeGhost ( false );
				ResetRigidbody ();
			}
		} */
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Book") {
			//if (OnBolaDestruida != null)
				//OnBolaDestruida ();
			Destroy (gameObject,0.3f);
		}
	}

	void ResetRigidbody() {
		rgb.velocity = Vector3.zero;
		rgb.angularVelocity = Vector3.zero;
		rgb.drag = 0f;
		rgb.inertiaTensorRotation = Quaternion.identity;
		rgb.ResetInertiaTensor ();
	}

	void MakeGhost( bool state ) {
		if (state) {
			rgb.isKinematic = true;
			col.enabled = false;
			Color c = m.color;
			c.a = 30 / 256f;
			m.color = c;
		} else {
			rgb.isKinematic = false;
			col.enabled = true;
			Color c = m.color;
			c.a = 1f;
			m.color = c;
		}
	}
}
