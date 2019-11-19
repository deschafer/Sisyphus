/*
	BiomeGrass
	
	Author: Graeme Holliday
	Purpose: Define the properties of the grass biome.
*/

using UnityEngine;

public class BiomeGrass : BiomeBase {

	/*
		Constructor

		Purpose: Set the properties to be appropriate for the biome.
	*/
	public BiomeGrass() {
		this.frequency = 0.04f;
		this.top = (GameObject)Resources.Load("Tiles/grass_top");
		this.fill = (GameObject)Resources.Load("Tiles/dirt");
		this.decoration = (GameObject)Resources.Load("Tiles/grass_plant");
		this.liquid = BiomeBase.Liquid.WATER;
	}

}
