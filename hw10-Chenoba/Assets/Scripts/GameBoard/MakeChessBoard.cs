using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ChessBoard
{
	public int nCol, nRow;
}


public class MakeChessBoard : MonoBehaviour {

	public ChessBoard chboard;
	public GameObject blackTile;
	public GameObject whiteTile;


	// Use this for initialization
	void Start () {
		
		FillChessBoard ();

	}
		

	void FillChessBoard() 
	{
		int isWhiteTile;
		float x, z;
		string tagName;
		GameObject tileObj;
		Vector3 tilePosition;
		Quaternion qRot = Quaternion.Euler(new Vector3(-90.0f,0f,0f));


		x = -chboard.nCol + 1f;
		for (int i=0; i<chboard.nCol; i++) {

			z = -chboard.nRow + 1f;
			for (int k = 0; k < chboard.nRow; k++) {
				tilePosition = new Vector3 (x, 0f, z);
				isWhiteTile = (i + k) % 2;
				if (isWhiteTile == 1) {
					tileObj = Instantiate (whiteTile, tilePosition, qRot) as GameObject;
				} else {
					tileObj = Instantiate (blackTile, tilePosition, qRot) as GameObject;
				}
				tagName = "tile_" + x.ToString () + "x" + z.ToString ();
				tileObj.gameObject.name = tagName;
				tileObj.gameObject.tag = "Tile";
				//Debug.Log (tagName);
				z += 2f;
			}
			x += 2f;
		}
	}
}
