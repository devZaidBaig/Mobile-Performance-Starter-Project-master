using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : MonoBehaviour {
    public bool hasBeenPlayed = false;
    private GameObject pieceBeingHeld;

    public void inPlay()
    {
        if (hasBeenPlayed == false)
        {
                pieceBeingHeld = gameObject;
        }
    }
    public void playPiece() {
        hasBeenPlayed = true;
        //Tell our GameLogic script to occupy the game board array at the right location with a player piece
    }
}
