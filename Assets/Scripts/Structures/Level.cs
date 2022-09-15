using System;
using System.Collections.Generic;

[Serializable]
public struct Level
{
    public List<SpawnObject> objectsToSpawn;
    public List<Getter> getters;
}
