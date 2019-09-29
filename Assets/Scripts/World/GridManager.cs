using UnityEngine;

//TODO: call this, shouldn't be monobehaviour
public class GridManager : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {
		Chunk c = ChunkFactory.GenerateChunk(40, 10, 3, 1);
		GameObject baseTile = (GameObject)Instantiate(Resources.Load("grass_center"));

		for(int y = 0; y < Chunk.CHUNK_HEIGHT; y++) {
			for(int x = 0; x < Chunk.CHUNK_WIDTH; x++) {
				if(c.tempGrid[x,y] == 1) {
					GameObject tile = (GameObject)Instantiate(baseTile, this.transform);
					tile.transform.position = new Vector2(x, -y);
				}
			}
		}

		Destroy(baseTile);
    }

}
