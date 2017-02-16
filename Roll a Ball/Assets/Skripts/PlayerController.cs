using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{
    private Rigidbody rb;
    public float speed;
    private int count;
    public Text countText;
    public int countMax;
    public Text winText;

    void Start(){
        rb = GetComponent<Rigidbody>();
        count = 0;
        countMax = 8;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            if (count == countMax)
                winText.text = "YOU WON!";
                
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
