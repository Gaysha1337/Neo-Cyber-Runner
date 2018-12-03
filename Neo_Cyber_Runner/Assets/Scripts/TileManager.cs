using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public GameObject[] tilePrefabs;
	public Transform playerTransform;
	private float tileLength = 14.0f;
	private int amntOfTilesOnScreen = 15;
	private float prefabSpawnZ = -3.0f;
	private int latestPrefabIndex = 0; // 0, since the first tile that spawns in the game has an index of 0
	private float safeZone = 30.0f; // used to decrease the player z axis, to attain a bigger value 
	

	// Use this for initialization
	void Start () {
		for(int i = 0; i<amntOfTilesOnScreen;i++){
			if(i <=3){
				SpawnTile(0);
			}
			else{
				SpawnTile();
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPostion = playerTransform.position;
		float amntOfSpawnedClones = amntOfTilesOnScreen + tileLength; // get the distance from the first clone to the last one

		// when the player cross a bridge, a new one is instantiated
		// I added the "safeZone" so that the player's z axis is bigger
		if(playerPostion.z + safeZone > prefabSpawnZ - amntOfSpawnedClones){
			SpawnTile();
			DeleteTile();
		}	
	}

	// Spawns either a random tile (dont specify and index in args) or a tile with a specific index (specify index as an arg)
	void SpawnTile(int prefabIndex = -1){
		GameObject clone; // the clone of the tile
		if (prefabIndex == -1){ // spawns a tile with a random index
			clone = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
		}
		else{ // spawns a tile with a specfied index
			clone = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
		}

		// setting the clones under the empty TileManager GameObject, so it looks tidy and organized
		clone.transform.SetParent(transform);

		// move the clone forward by the z axis of the clone
		clone.transform.position = Vector3.forward * prefabSpawnZ;

		// increment the z axis of the clone, by adding the lenght of a single tile to the z axis of the previously cloned tile
		prefabSpawnZ += tileLength;
	}


	int RandomPrefabIndex (){
		if(tilePrefabs.Length <= 1){
			// if there is only 1 or less tiles in the tile prefab array, 
			//then the index will be 0, since 0 is the index of the first element of an array
			return 0;
		}
		int randomIndex = latestPrefabIndex;
		// While the last prefab index is equal to a random index, generate a random index value
		while(randomIndex==latestPrefabIndex){
			randomIndex = Random.Range(0,tilePrefabs.Length);
		}
		latestPrefabIndex = randomIndex; // The lastest prefab will now euqaé to the random index
		return randomIndex;

	}

	private void DeleteTile(){
		Destroy(transform.GetChild(0).gameObject);
	}

}
