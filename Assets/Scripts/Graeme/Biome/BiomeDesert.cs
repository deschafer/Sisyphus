/*
	BiomeDesert
	
	Author: Graeme Holliday
	Purpose: Define the properties of the desert biome.
*/

using UnityEngine;

public class BiomeDesert : BiomeBase {

	/*
		Constructor

		Purpose: Set the properties to be appropriate for the biome.
	*/
	public BiomeDesert() {
		this.frequency = 0.02f;
		this.top = (GameObject)Resources.Load("Tiles/sand_top");
		this.fill = (GameObject)Resources.Load("Tiles/dirt");
		this.decoration = (GameObject)Resources.Load("Tiles/cactus");
		this.liquid = BiomeBase.Liquid.NONE;
	}

}
