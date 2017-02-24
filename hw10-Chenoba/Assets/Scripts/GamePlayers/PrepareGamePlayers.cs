using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PrepareGamePlayers : MonoBehaviour {

	public GameObject gameBoard;
	private int xMin, xMax, zMin, zMax;


	// Use this for initialization
	void Start () {
		var boardsize = gameBoard.GetComponent<MakeChessBoard> ().chboard;
		xMin = -boardsize.nCol + 1;
		xMax = boardsize.nCol - 1;
		zMin = -boardsize.nRow + 1;
		zMax = boardsize.nRow - 1;
//		Debug.Log ("xMin: " + xMin + ", " + "xMax: " + xMax);
//		Debug.Log ("zMin: " + zMin + ", " + "zMax: " + zMax);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void PrepareWhitePlayers () {
		
	}


	void PrepareBlackPlayers () {
	}
}
