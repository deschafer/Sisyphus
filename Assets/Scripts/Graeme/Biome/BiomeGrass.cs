using UnityEngine;

public class BiomeGrass : BiomeBase {

	public BiomeGrass() {
		this.frequency = 0.04f;
		this.top = (GameObject)Resources.Load("Tiles/grass_top");
		this.fill = (GameObject)Resources.Load("Tiles/dirt");
		this.platform = (GameObject)Resources.Load("Tiles/grass_platform");
	}

	public override Chunk decorate() {
		//write this
		return new Chunk(new int[2,2], this);
	}

}
