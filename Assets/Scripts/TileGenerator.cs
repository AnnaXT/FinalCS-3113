using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnXRight = 19.0f;
    private float spawnYUp = 19.0f;
    private float spawnXLeft = -19.0f;
    private float spawnYDown = -19.0f;
    private float tileLength = 19f;
    private int tileNum = 3;

    private List<List<GameObject>> tiles;


    void Start()
    {
        tiles = new List<List<GameObject>>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        spawnXRight = playerTransform.position.x + tileLength;
        spawnXLeft = playerTransform.position.x - tileLength;
        spawnYUp = playerTransform.position.y + tileLength;
        spawnYDown = playerTransform.position.y - tileLength;
        for(int j = 0; j < tileNum; j++){
            List<GameObject> currTiles = new List<GameObject>();
            for(float i = spawnYDown; i <= spawnYUp; i += tileLength){
                GameObject go;
                go = Instantiate(tilePrefabs[0]) as GameObject;
                go.transform.SetParent(transform);
                go.transform.position = new Vector3(1 * playerTransform.position.x, 1 * i, 0);
                currTiles.Add(go);
            }
            tiles.Add(currTiles);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.x > (spawnXRight - tileNum * tileLength)){
            SpawnTileRight(0);
            if(playerTransform.position.x > (spawnXLeft + tileNum * tileLength)){
                DeleteTileLeft();
            }
        }
        if(playerTransform.position.x < (spawnXLeft + tileNum * tileLength)){
            SpawnTileLeft(0);
            if (playerTransform.position.x < (spawnXRight - tileNum * tileLength)){
                DeleteTileRight();
            }
        }
        if(playerTransform.position.y > (spawnYUp - tileNum * tileLength)){
            SpawnTileUp(0);
            if(playerTransform.position.y > (spawnYDown + tileNum * tileLength)){
                DeleteTileDown();
            }
        }

        if(playerTransform.position.y < (spawnYDown + tileNum * tileLength)){
            SpawnTileDown(0);
            if(playerTransform.position.y < (spawnYUp - tileNum * tileLength)){
                DeleteTileUp();
            }
        }
        
    }

    void SpawnTileRight(int prefabIndex = -1){
        List<GameObject> currTiles = new List<GameObject>();
        for(float i = spawnYDown; i <= spawnYUp; i += tileLength){
            GameObject go;
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
            go.transform.SetParent(transform);
            go.transform.position = new Vector3(1 * spawnXRight, 1 * i, 0);
            currTiles.Add(go);
        }
        tiles.Add(currTiles);
        spawnXRight += tileLength;
    }

    void SpawnTileLeft(int prefabIndex = -1){
        List<GameObject> currTiles = new List<GameObject>();
        for(float i = spawnYDown; i <= spawnYUp; i += tileLength){
            GameObject go;
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
            go.transform.SetParent(transform);
            go.transform.position = new Vector3(1 * spawnXLeft, 1 * i, 0);
            currTiles.Add(go);
        }
        tiles.Insert(0, currTiles);
        spawnXLeft -= tileLength;
    }

    void SpawnTileUp(int prefabIndex = -1){
        List<GameObject> currTiles = new List<GameObject>();
        int counter = 0;
        for(float i = spawnXLeft; i <= spawnXRight; i += tileLength){
            GameObject go;
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
            go.transform.SetParent(transform);
            go.transform.position = new Vector3(1 * i, 1 * spawnYUp, 0);
            tiles[counter].Insert(0, go);
            counter += 1;
        }
        spawnYUp += tileLength;
    }

    void SpawnTileDown(int prefabIndex = -1){
        List<GameObject> currTiles = new List<GameObject>();
        int counter = 0;
        for(float i = spawnXLeft; i <= spawnXRight; i += tileLength){
            GameObject go;
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
            go.transform.SetParent(transform);
            go.transform.position = new Vector3(1 * i, 1 * spawnYDown, 0);
            tiles[counter].Add(go);
            counter += 1;
        }
        spawnYDown -= tileLength;
    }

    void DeleteTileLeft(){
        for(int i = 0; i < tiles[0].Count; ++i){
            Destroy(tiles[0][i]);
        }
        tiles.RemoveAt(0);
        spawnXLeft += tileLength;
            
    }

    void DeleteTileRight(){
        int length = tiles.Count;
        for(int i = 0; i < tiles[length - 1].Count; ++i){
            Destroy(tiles[length - 1][i]);
        }
        tiles.RemoveAt(length - 1);
        spawnXRight -= tileLength;
            
    }

    void DeleteTileUp(){
        int length = tiles.Count;
        for(int i = 0; i < length; ++i){
            Destroy(tiles[i][0]);
            tiles[i].RemoveAt(0);
        }
        spawnYUp -= tileLength;
            
    }

    void DeleteTileDown(){
        int length = tiles.Count;
        for(int i = 0; i < length; ++i){
            int index = tiles[i].Count - 1;
            Destroy(tiles[i][index]);
            tiles[i].RemoveAt(index);
        }
        spawnYDown += tileLength;
            
    }
}
