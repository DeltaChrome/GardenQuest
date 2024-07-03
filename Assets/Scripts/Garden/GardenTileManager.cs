using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenTileManager : MonoBehaviour
{

    public GameObject Tile;
    GameObject [,] TilesArray;
    const int GRID_SIZE = 25;
    const int TILE_SIZE = 100;
    const int TILE_PADDING = 5;
    const int OFFSET = 0;

    // Start is called before the first frame update
    void Start()
    {
        TilesArray =  new GameObject[GRID_SIZE,GRID_SIZE];
        
        for(int i = 0; i < GRID_SIZE; ++i)
        {
            for(int j = 0; j < GRID_SIZE; ++j)
            {
                //Tile = new GameObject();
                //GameObject T;
                Tile.transform.position = new Vector3(0,0,0);
                Tile.transform.Translate(i * (TILE_SIZE + TILE_PADDING) + OFFSET, j * (TILE_SIZE + TILE_PADDING) + OFFSET, 0);
                Instantiate(Tile, Tile.transform.position, Tile.transform.rotation);
                TilesArray[i,j] = Tile;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
