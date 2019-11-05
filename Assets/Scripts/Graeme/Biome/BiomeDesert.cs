using UnityEngine;

public class BiomeDesert : BiomeBase {

	public BiomeDesert() {
		this.frequency = 0.02f;
		this.top = (GameObject)Resources.Load("Tiles/sand_top");
		this.fill = (GameObject)Resources.Load("Tiles/dirt");
		this.platform = (GameObject)Resources.Load("Tiles/sand_platform");
	}

	public override Chunk decorate() {
		//write this
		return new Chunk(new int[2, 2], this);
	}

}
