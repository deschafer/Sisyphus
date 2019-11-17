using UnityEngine;

public class BiomeSnow : BiomeBase {

	public BiomeSnow() {
		this.frequency = 0.06f;
		this.top = (GameObject)Resources.Load("Tiles/snow_top");
		this.fill = (GameObject)Resources.Load("Tiles/snow");
		this.decoration = (GameObject)Resources.Load("Tiles/spikes");
		this.liquid = BiomeBase.Liquid.NONE;
	}

}
