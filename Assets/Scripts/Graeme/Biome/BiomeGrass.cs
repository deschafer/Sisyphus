using UnityEngine;

public class BiomeGrass : BiomeBase {

	public BiomeGrass() {
		this.frequency = 0.04f;
		this.top = (GameObject)Resources.Load("Tiles/grass_top");
		this.fill = (GameObject)Resources.Load("Tiles/dirt");
		this.decoration = (GameObject)Resources.Load("Tiles/grass_plant");
		this.liquid = BiomeBase.Liquid.WATER;
	}

}
