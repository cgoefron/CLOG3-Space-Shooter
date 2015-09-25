using UnityEngine;
using System.Collections;

public class AsteroidDestroy : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	private GameController gameController;

	
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log ("Collider triggered");
		
		if (other.tag == "Boundary")
		{
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);

				Application.LoadLevel(Application.loadedLevel);
		}

		Destroy (other.gameObject);
		Destroy (gameObject);
	}
	}

