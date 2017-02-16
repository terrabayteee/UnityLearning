using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {
    private GameController gameController;
    private DestroyByContact destroyByContact;
    void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null) {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Enemy"){ 
            gameController.AddScore(-1);
        }
        Destroy(other.gameObject);
    }
}
