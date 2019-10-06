using UnityEngine;

public class WorldManager : MonoBehaviour {

    private int seed;
    //private EntityManager entityManager;
    private ChunkManager chunkManager;
    private int time;

	void Start() {
		//Temporary
		seed = Random.Range(int.MinValue, int.MaxValue);
		chunkManager = new ChunkManager(seed);
		time = 0;
		RenderChunk(chunkManager.GenerateChunk(0, 5f));
	}

	public void RenderChunk(Chunk c) {
		GameObject dirt = (GameObject)Instantiate(Resources.Load("dirt"));
		for (int y = 0; y < Chunk.CHUNK_HEIGHT; y++) {
			for (int x = 0; x < Chunk.CHUNK_WIDTH; x++) {
				if (c.tempGrid[x, y] == 1) {
					GameObject tile = (GameObject)Instantiate(dirt, this.transform);
					tile.transform.position = new Vector2(x, -y);
				}
			}
		}
		Destroy(dirt);
	}

}
