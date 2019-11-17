using UnityEngine;

public class BiomeBase {

	public GameObject top;
	public GameObject fill;
	public GameObject decoration;
	public Liquid liquid;

	public enum Liquid { LAVA, WATER, NONE }

	protected float frequency;

	public void decorate(Chunk c) {
		//First pass: Add liquids
		if(c.getBiome().liquid != Liquid.NONE) {
			for(int x = 1; x < Chunk.CHUNK_SIZE - 1; x++) {
				int y;
				for(y = 0; c.grid[x, y] == 0; y++) ;
				if(c.grid[x, y] == 1 && c.grid[x - 1, y - 1] == 0 && c.grid[x + 1, y - 1] == 0 && Random.Range(0, 1f) < 0.1f) {
					c.grid[x, y] = 4;
					c.grid[x, y + 1] = 5;
				}
			}
		}

		//Second pass: Add decorations
		for(int x = 0; x < Chunk.CHUNK_SIZE; x++) {
			int y;
			for(y = 0; c.grid[x, y] == 0; y++);
			if(c.grid[x, y] == 1 && Random.Range(0, 1f) < 0.1f)
				c.grid[x, y - 1] = 3;
		}
	}

}
