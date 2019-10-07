using UnityEngine;

public class Chunk {

	public const int CHUNK_WIDTH = 128;
	public const int CHUNK_HEIGHT = 32;

    private BiomeBase biome;

	//REMOVE THIS
	public int[,] tempGrid;

    public Chunk(int[,] grid) {
		tempGrid = grid;
    }

}
