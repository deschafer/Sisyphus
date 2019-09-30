using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager {

    private System.Random r;
    private ArrayList loadedChunks;

    public ChunkManager(int seed) {
        r = new System.Random(seed);
        loadedChunks = new ArrayList();
        //loadedChunks.Add(new Chunk());
    }

}
