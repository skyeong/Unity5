using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ChessBoard
{
	public int nCol, nRow;
}


public class GameBoardController : MonoBehaviour {

	public ChessBoard chboard;
	public GameObject blackTile;
	public GameObject whiteTile;


	// Use this for initialization
	void Start () {
		
		FillChessBoard ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}



	void FillChessBoard() 
	{
		int isWhiteTile;
		float x, y;
		string tagName;
		GameObject tileObj;
		Vector3 tilePosition;

		x = -chboard.nCol - 1f;
		for (int i=0; i<chboard.nCol; i++) {

			y = -chboard.nRow - 1f;
			for (int j = 0; j < chboard.nRow; j++) {
				tilePosition = new Vector3 (x, y, 0.1f);
				isWhiteTile = (i + j) % 2;
				if (isWhiteTile == 1) {
					tileObj = Instantiate (whiteTile, tilePosition, Quaternion.identity) as GameObject;
				} else {
					tileObj = Instantiate (blackTile, tilePosition, Quaternion.identity) as GameObject;
				}
				tagName = "tile_" + x.ToString () + "x" + y.ToString ();
				tileObj.gameObject.name = tagName;
				tileObj.gameObject.tag = "Tile";
				Debug.Log (tagName);
				y += 2f;
			}
			x += 2f;
		}
	}
}
