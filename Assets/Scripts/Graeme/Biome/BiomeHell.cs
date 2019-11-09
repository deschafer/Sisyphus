using UnityEngine;

public class BiomeHell : BiomeBase {

	public BiomeHell() {
		this.frequency = 0.06f;
		this.top = (GameObject)Resources.Load("Tiles/hell_top");
		this.fill = (GameObject)Resources.Load("Tiles/stone");
		this.platform = (GameObject)Resources.Load("Tiles/hell_platform");
	}

	public override Chunk decorate() {
		//write this
		return new Chunk(new int[2, 2], this);
	}

}
