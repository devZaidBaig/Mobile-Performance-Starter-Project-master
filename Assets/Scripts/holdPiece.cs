using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdPiece : MonoBehaviour {
    public GameObject GameLogic;
    public GameObject raycastHolder;
    public GameObject player;
    public GameObject pieceBeingHeld;
	public GameObject gravityAttractor;
    public bool holdingPiece = false;
    public float hoverHeight = 0.3f;

    RaycastHit hit;
	public float gravityFactor = 10.0f;

	public void grabPiece(GameObject selectedPiece) {
    
        if(selectedPiece.GetComponent<PlayerPiece>().hasBeenPlayed)
        {
            Debug.Log("This piece is already played!");
        }
        else{
            selectedPiece.GetComponent<PlayerPiece>().inPlay();
            pieceBeingHeld = selectedPiece;
            holdingPiece = true;
        }
    }
	// Update is called once per frame
	void FixedUpdate () {
        if (GameLogic.GetComponent<GameLogic>().playerTurn == true) {
            if (holdingPiece == true) {
                Vector3 forwardDir = raycastHolder.transform.TransformDirection(Vector3.forward) * 100;
                Debug.DrawRay(raycastHolder.transform.position, forwardDir, Color.green);


                if (Physics.Raycast(raycastHolder.transform.position, (forwardDir), out hit)) {
					gravityAttractor.transform.position = new Vector3(hit.point.x, hit.point.y + hoverHeight, hit.point.z);


					pieceBeingHeld.GetComponent<Rigidbody> ().useGravity = false;
					pieceBeingHeld.GetComponent<BoxCollider> ().enabled = false;

                    pieceBeingHeld.transform.position = Vector3.Lerp(pieceBeingHeld.transform.position, gravityAttractor.transform.position, 0.2f);


                    if (Input.GetMouseButtonDown(0)) {
                        if (hit.collider.gameObject.tag == "Grid Plate") {
                            pieceBeingHeld.GetComponent<PlayerPiece>().playPiece();
                            holdingPiece = false;

                            hit.collider.gameObject.SetActive(false);
                            GameLogic.GetComponent<GameLogic>().playerMove(hit.collider.gameObject);
                        }

                    }
                }
            }
        }
    }

}