using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
	public float tilt;
	public Done_Boundary boundary;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;
	
	public float speed = 1.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 move = new Vector3((Input.GetAxis("Vertical")*-1), 0, Input.GetAxis("Horizontal"));
		transform.position += move * speed * Time.deltaTime;

		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
	}
}
