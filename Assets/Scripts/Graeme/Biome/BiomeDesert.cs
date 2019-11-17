using UnityEngine;

public class BiomeDesert : BiomeBase {

	public BiomeDesert() {
		this.frequency = 0.02f;
		this.top = (GameObject)Resources.Load("Tiles/sand_top");
		this.fill = (GameObject)Resources.Load("Tiles/dirt");
		this.decoration = (GameObject)Resources.Load("Tiles/cactus");
		this.liquid = BiomeBase.Liquid.NONE;
	}

}
