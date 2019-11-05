using UnityEngine;

public class BiomeSnow : BiomeBase {

	public BiomeSnow() {
		this.frequency = 0.06f;
		this.top = (GameObject)Resources.Load("Tiles/snow_top");
		this.fill = (GameObject)Resources.Load("Tiles/snow");
		this.platform = (GameObject)Resources.Load("Tiles/snow_platform");
	}

	public override Chunk decorate() {
		//write this
		return new Chunk(new int[2, 2], this);
	}

}
