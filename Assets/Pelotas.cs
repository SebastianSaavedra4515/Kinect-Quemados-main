using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelotas : MonoBehaviour {

	public Rigidbody rig;
	public float force, upForce=10;
	public GameObject Player;
	public GameObject Spawner;
	public bool have_force = false;
	PhysicMaterial fisica;
	public float rebote;
	// Use this for initialization
	void Start () 
	{
		this.fisica = new PhysicMaterial();
		this.fisica.bounciness = this.rebote;
		this.fisica.frictionCombine = PhysicMaterialCombine.Minimum;
		this.fisica.bounceCombine = PhysicMaterialCombine.Maximum;
		force = Random.Range(3, upForce);
		GetComponent<SphereCollider>().material = this.fisica;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 direction = Player.transform.position - this.Spawner.transform.position;
		Move(direction);
    }
	public void Move(Vector3 dir)
    {
		if(!have_force)
        {
			rig.AddForce(dir.normalized * this.force, ForceMode.Impulse);
			rig.AddForce(this.transform.up * this.force, ForceMode.Impulse);
        }
		this.have_force = true;
    }
	void OnCollisionEnter(Collision collision)
    {
		//if(collision.gameObject.tag == "Player")
  //      {
		//	Destroy(this.gameObject);
		//}
	}
}
