using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	
	public float speed; //will show up in the inspector to edit
	public GUIText countText; //shows how many cubes have been picked up
	public GUIText winText; //shows message when you win the game
	private int count; //counting the cubes as they are picked up
	
	void Start()
	{
		count = 0; //starts count at 0
		SetCountText(); //called method to add cubes as they are picked up
		winText.text = "";  //empty at game start
	}
	
	//called before performed any physics caluclations
	//where physics code is placed
	//what will move the Player (sphere)
	void FixedUpdate()
	{
		//receives input from the player
		float moveHorzontal = Input.GetAxis("Horizontal"); 
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorzontal,0.0f,moveVertical);
		
		rigidbody.AddForce(movement * speed * Time.deltaTime);
	}
	
	//when the player hits the game object labeled "PickUp"
	//the game object be deactivate and disappear
	void OnTriggerEnter(Collider other) 
	{
        if(other.gameObject.tag =="PickUp")
		{
			other.gameObject.SetActive(false);
			count = count + 1; //increases number of cubes picked up
			SetCountText();   //called method to add cubes as they are picked up
		}
    }
	
	void SetCountText()  //shows the number of picked up cubes in the GUI
	{
		countText.text = "Count: " + count.ToString();
		if(count >= 12)
		{
			winText.text = "You Win!";
		}
	}
}
