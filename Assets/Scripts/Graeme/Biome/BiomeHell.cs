﻿/*
	BiomeHell
	
	Author: Graeme Holliday
	Purpose: Define the properties of the hell biome.
*/

using UnityEngine;

public class BiomeHell : BiomeBase {

	/*
		Constructor

		Purpose: Set the properties to be appropriate for the biome.
	*/
	public BiomeHell() {
		this.frequency = 0.06f;
		this.top = (GameObject)Resources.Load("Tiles/hell_top");
		this.fill = (GameObject)Resources.Load("Tiles/stone");
		this.decoration = (GameObject)Resources.Load("Tiles/boulder");
		this.liquid = BiomeBase.Liquid.LAVA;
	}

}
