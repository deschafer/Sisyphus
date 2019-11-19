/*
	Chunk

	Author: Graeme Holliday
	Purpose: Hold and control access to the data relevant to a chunk, which is a n x n grid of tiles.
*/

public class Chunk {

	public const int CHUNK_SIZE = 32;

    private BiomeBase biome;
	public int[,] grid;

	/*
		Constructor

		Parameters: 2D array of ints representing the tile types, the biome of the chunk.
		Purpose: Initialize the data values.
	*/
    public Chunk(int[,] grid, BiomeBase biome) {
		this.grid = grid;
		this.biome = biome;
		biome.decorate(this);
    }

	/*
		getBiome

		Returns: The biome of the chunk.
		Purpose: Access the read-only biome field.
	*/
	public BiomeBase getBiome() {
		return this.biome;
	}

}
