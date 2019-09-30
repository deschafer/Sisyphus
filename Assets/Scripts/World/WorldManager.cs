using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager {

    private int seed;
    //private EntityManager entityManager;
    private ChunkManager chunkManager;
    private int time;
    public WorldManager() {
        //If we're loading from a save this will change.
        seed = (new System.Random()).Next();
        chunkManager = new ChunkManager(seed);
        time = 0;
        //init seed
    }

}
