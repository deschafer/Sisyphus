using UnityEngine;

public class WorldManager : MonoBehaviour {

    private int seed;
    //private EntityManager entityManager;
    private ChunkManager chunkManager;
    private int time;

	public WorldManager() {
		//Temporary
		seed = Random.Range(int.MinValue, int.MaxValue);
		//chunkManager = new ChunkManager(seed);
		time = 0;
	}

}
