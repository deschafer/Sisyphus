using UnityEngine;

public class Chunk {

	public const int CHUNK_WIDTH = 32;
	public const int CHUNK_HEIGHT = 32;

    private BiomeBase biome;

	//will be private
	public int[,] tempGrid;

    public Chunk(int[,] grid) {
		tempGrid = grid;
    }

}
