public class Chunk {

	public const int CHUNK_SIZE = 32;

    private BiomeBase biome;
	public int[,] grid;

    public Chunk(int[,] grid, BiomeBase biome) {
		this.grid = grid;
		this.biome = biome;
		biome.decorate(this);
    }

	public BiomeBase getBiome() {
		return this.biome;
	}

}
