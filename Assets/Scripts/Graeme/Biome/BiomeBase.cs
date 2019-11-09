using UnityEngine;

public abstract class BiomeBase {

	public GameObject top;
	public GameObject fill;
	public GameObject platform;

	protected float frequency;

	public abstract Chunk decorate();

}
