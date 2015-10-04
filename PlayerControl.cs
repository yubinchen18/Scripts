using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	private int count;
	public GUIStyle labelstyle;
	public GUIStyle labelstyle2;
	private string winText = "YOU WIN!";

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count += 1;
		}
	}
	
	void OnGUI()
	{
		GUI.Label (new Rect (10,10,100,20), string.Format ("Count: " +  count), labelstyle);
		
		
		
		if(count >= 8)
			GUI.Button (new Rect(Screen.width/2-198, Screen.height/2-200, 397, 478), winText, labelstyle2);
	}
	
	
	
	
}
