using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

public class GameTile : Tile {

	public Sprite[] GetSprite(string textureName) {
		Sprite[] myTextures = Resources.LoadAll<Sprite>("Textures/" + textureName);
		return myTextures;
	}

	public void UpdateDB(Object myAT, string name) {
		AssetDatabase.CreateAsset(myAT, "Assets/Tiles/" + name + "");
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
	}

	//Ich denke die Funktion wird aufgerufen, wenn das Tile sich selbst auf die Tilemap zeichnet
	public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData) {
		int mask = (HasNeighbour(position + Vector3Int.up, tilemap) ? 1 : 0)
				+ (HasNeighbour(position + Vector3Int.right, tilemap) ? 2 : 0)
				+ (HasNeighbour(position + Vector3Int.down, tilemap) ? 4 : 0)
				+ (HasNeighbour(position + Vector3Int.left, tilemap) ? 8 : 0);


		//set the tile texture based on the surrounding tiles
	}

	public Sprite[] LoadTexture() {
		Sprite[] myTextures = Resources.LoadAll<Sprite>("LavaWalls");
		//Das hat funktioniert
		return myTextures;
	}

	public bool HasNeighbour(Vector3Int position, ITilemap tilemap) {
		TileBase tile = tilemap.GetTile(position);
		//tiledata check must be same kind of tile type

		//Important to check name property because we want tiles to change form depending on same name
		return (tile != null && tile.name == this.name);
	}

}
