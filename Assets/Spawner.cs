using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
	public GameObject pelota;
	public GameObject Player;
	public Transform Posicionarrojo;
	public float TimeMax=4;
	public float time=0;
	public Animator anim;
	// Use this for initialization
	void Start()
	{
		
		this.pelota.GetComponent<Pelotas>().Player = this.Player;
		this.pelota.GetComponent<Pelotas>().Spawner = this.gameObject;
	}

	// Update is called once per frame
	void Update()
	{
		time += Time.deltaTime;

		if (time>=TimeMax)
		{
			anim.SetTrigger("Lanzar");
			if(time>=TimeMax+1)
			{
				pelota.transform.position = new Vector3(this.Posicionarrojo.position.x, this.Posicionarrojo.position.y, this.Posicionarrojo.position.z);
				GameObject pelotaLanzada = Instantiate(pelota);
				TimeMax = Random.Range(2, 4);
				time = 0;

			}
		}
	}
}
