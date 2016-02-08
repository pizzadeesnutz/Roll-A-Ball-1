using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    //variables needed for Player
    private Rigidbody rb;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;

    //Start runs automatically, kind of like main method in Java
	void Start(){
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    //This is what actually moves the ball, y value is ALWAYS 0 that way we stay on the plane
    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    //This code sets what happens when we hit shit in the game
    void OnTriggerEnter(Collider other){
        //when we hit the objects tagged pick up, do this stuff
        if(other.gameObject.CompareTag("Pick Up")){
            other.gameObject.SetActive(false);//hides the pick ups
            count++;//increments count up by 1
            SetCountText();//calls the function we created to change the UI display
        }
   }

    //this function sets the counter display text
    void SetCountText(){
        countText.text = "Count " + count.ToString();
        if(count >= 12){
            winText.text = "You Win!";
        }
    }
}