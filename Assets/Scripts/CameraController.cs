using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public GameObject player; //player object
	private Vector3 offset; //offset value from player to camera

	// Use this for initialization
	void Start () 
	{
		offset = transform.position; //distance the player is from the camera
	}
	
	// Update is called once per frame
	void LateUpdate()
	{
		transform.position = player.transform.position + offset; //changes the distance as the player moves
	
	}
}
