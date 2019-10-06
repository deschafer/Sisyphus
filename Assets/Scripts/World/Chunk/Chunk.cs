using UnityEngine;

public class Chunk {

	public const int CHUNK_WIDTH = 32;
	public const int CHUNK_HEIGHT = 32;

    private BiomeBase biome;
	private int positionX;

	//REMOVE THIS
	public int[,] tempGrid;

    public Chunk(int[,] grid) {
		tempGrid = grid;
    }

	public int getX() {
		return positionX;
	}

}
