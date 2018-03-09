using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomLevelMaker_cfd: MonoBehaviour {

	ObjectMatrix om;
	int rows;
	int columns;
	int[] enemy_position_x;
	int[] enemy_position_z;
	//EnemyController[] enemy_movement_script_list;

	int woodenBox_spawn_count = 0;//need it as we need to know where to spawn powerUps, stars etc
//	int total_objects_spawned;

	public GameObject star_cube;
	public GameObject woodenBox_visible;
	public GameObject woodenBox_invisible;
	public GameObject level;
	public GameObject enemy_moves;//WHEN MOVES
	public GameObject enemy_still;//WHEN SHOWED INITIALLY
	public GameObject power_up_increase_blast;
	public GameObject power_up_increase_speed;

	public float selectorThreshold;
	public int max_no_of_enemies;
	public int max_no_of_power_ups;
	public int max_star_cubes;
	public int star_cubes_count = 0;//public so can be used in other script
	public int enemyCount = 0;//public so can be used in other script
	public int power_ups_count = 0;//public so can be used in other script

	public float distancePerEnemy_x;//actual distance in units is obtained by multiplying this by skipFactor
	public float distancePerEnemy_z;//actual distance in units is obtained by multiplying this by skipFactor
	public int skipFactor;	
	//public int enemies_per_section;
	public float remember_time;


	public Text label_enemy;
	public Text label_PowerUp;
	public Text label_WinnerStar;

	void Start(){
		Debug.Log ("shart lagi h bhai!!");
		//power_ups_count = 0;
		//woodenBox_spawn_count = 0;
		//star_cubes_count = 0;
		//enemyCount = 0;
		//total_objects_spawned = 0;
	}

	void Update(){
		label_enemy.text = "" + enemyCount;
		Debug.Log ("enemyCount: " + enemyCount);
		label_PowerUp.text = "" + power_ups_count;
		label_WinnerStar.text = "" + star_cubes_count;
	}


	public void generateLevel() {
		//enemy_movement_script_list = new EnemyController[max_no_of_enemies];
		//enemyCount = 0;//no of enemies spawned so far
		om = GameObject.Find("GameController").GetComponent<ObjectMatrix>();
		rows = om.rows;//rows on the game field
		columns = om.columns;//columns on the game field
		int enemySections_x = rows/((int)distancePerEnemy_x*skipFactor);//no of sections in x direction in which game field is divided
		int enemySections_z = columns/((int)distancePerEnemy_z*skipFactor);//no of sections in z direction in which game field is divided
		//NOTE: enemies_per_section NUMBER OF ENEMIES ARE SPAWNED IN ONE SECTION, SAME FOR ALL SECTIONS 
		

		max_no_of_enemies = (max_no_of_enemies < enemySections_z + enemySections_z)? max_no_of_enemies:enemySections_z + enemySections_z; 

		enemy_position_x = new int[max_no_of_enemies];//array containing x-coordinates of enemies spawn positions
		enemy_position_z = new int[max_no_of_enemies];//array containing z-coordinates of enemies spawn positions
		//Debug.Log("enemySections_x: "+enemySections_x);
		//Debug.Log("enemySections_z: "+enemySections_z);

		for(int i=0; i<max_no_of_enemies; i++){
			enemy_position_x[i] = (int)Random.Range(0.0f, distancePerEnemy_x);//random numbers are used as x-coordinates
			enemy_position_z[i] = (int)Random.Range(0.0f, distancePerEnemy_z);//random numbers are used as z-coordinates
		}//this has generated two random numbers for each enemy



		//SPAWNING ENEMIES
		for(int i=0; i<enemySections_x; i++){

			if(enemyCount == max_no_of_enemies){
				//Debug.Log ("break2");	
				break;
			}

			for(int j=0; j<enemySections_z; j++){
				//Debug.Log("i: "+i);
				//Debug.Log("j: "+j);
				if(i==0 && j==0){
					continue;
				}

				if(enemyCount == max_no_of_enemies){
					//Debug.Log ("break1");
					break;
				}

				int x_coordinate = skipFactor*((int)distancePerEnemy_x*(i) + enemy_position_x[i+j]);
				int z_coordinate = skipFactor*((int)distancePerEnemy_z*(j) + enemy_position_z[i+j]);
				//Debug.Log("x_coordinate: "+x_coordinate);
				//Debug.Log("z_coordinate: "+z_coordinate);
				if(x_coordinate <= rows-2 && z_coordinate <= columns-2 && om.level[x_coordinate, z_coordinate] == null){
					GameObject enemySpawned = Instantiate(enemy_still, new Vector3(x_coordinate, 0, z_coordinate), Quaternion.identity);
					om.level[x_coordinate, z_coordinate] = enemySpawned.gameObject;
					enemySpawned.transform.parent = level.transform;
					//enemy_movement_script_list[enemyCount] = enemySpawned.GetComponent<EnemyController>();
					enemyCount++;
					Debug.Log ("enemyCount2: " + enemyCount);
					//total_objects_spawned++;
				}
			}
			
				
		}		


		//CLEARING AREA NEAR PLAYER AND SPAWNING WOODEN BOXES
		for(int i=0; i<rows-1; i++){
			for(int j=0; j<columns-1; j++){
				
				if(i==0 && j==0 || i==1 && j==0 || i==0 && j==1){
					continue;
				}//used to clear a certain area near the player
				
				if (om.level [i, j] == null) {
					float selector = Random.Range (0.0f, 1.0f);
					if (selector < selectorThreshold) {
						GameObject spawnedWoodenBox;
						//GameObject spawnedWoodenBox = Instantiate(woodenBox_visible, new Vector3(i, 0, j), Quaternion.identity);
						//om.level[i,j] = spawnedWoodenBox.gameObject;
						//woodenBox_spawn_count++;
						//total_objects_spawned++;
						if (woodenBox_spawn_count == 10) {//power up in 7th cube
							//spawnedWoodenBox.transform.gameObject.tag = "woodenBox_power_up_increase_blast";//set tag of wooden box with power inside it as woodenBox_power_up
							spawnedWoodenBox = Instantiate (power_up_increase_blast, new Vector3 (i, 0, j), Quaternion.identity);
							om.level [i, j] = spawnedWoodenBox.gameObject;
							power_ups_count++;
							woodenBox_spawn_count++;
							//total_objects_spawned++;
						} else if (woodenBox_spawn_count == 16) {//power up in 12th cube
							//spawnedWoodenBox.transform.gameObject.tag = "woodenBox_power_up_increase_speed";//set tag of wooden box with power inside it as woodenBox_power_up
							spawnedWoodenBox = Instantiate (power_up_increase_speed, new Vector3 (i, 0, j), Quaternion.identity);
							om.level [i, j] = spawnedWoodenBox.gameObject;
							power_ups_count++;
							woodenBox_spawn_count++;
							//total_objects_spawned++;
						} else if (woodenBox_spawn_count == 5) {//star in 12th cube
							spawnedWoodenBox = Instantiate (star_cube, new Vector3 (i, 0, j), Quaternion.identity);
							om.level [i, j] = spawnedWoodenBox.gameObject;
							star_cubes_count++;
							woodenBox_spawn_count++;
							//total_objects_spawned++;
						} else if (woodenBox_spawn_count == 20) {//star in 20th cube
							spawnedWoodenBox = Instantiate (star_cube, new Vector3 (i, 0, j), Quaternion.identity);
							om.level [i, j] = spawnedWoodenBox.gameObject;
							star_cubes_count++;
							woodenBox_spawn_count++;
							//total_objects_spawned++;
						} else {
							spawnedWoodenBox = Instantiate (woodenBox_visible, new Vector3 (i, 0, j), Quaternion.identity);
							om.level [i, j] = spawnedWoodenBox.gameObject;
							woodenBox_spawn_count++;
							//total_objects_spawned++;
						}
						spawnedWoodenBox.transform.parent = level.transform;
						Debug.Log("spawned_wooden_boxes" + woodenBox_spawn_count);
					}
				} else if(om.level [i, j].gameObject.tag != "Enemy_still"){
					om.level [i, j].gameObject.tag = "fixed_box";
				}

				/*else if(om.level[i,j].gameObject.tag=="Enemy"){
					om.level[i,j] = null;
				}*/

			}
		}
		Debug.Log ("here1");
		StartCoroutine (hide_everything ());
		Debug.Log ("here2");


	}

	IEnumerator hide_everything(){
		Debug.Log ("coroutine called");
		yield return new WaitForSeconds (remember_time);
		make_invisible ();
		yield return new WaitForSeconds (0);
	}

	//CALL IT WHEN BUTTON IS PRESSED
	public void make_invisible(){
		Debug.Log ("func called");
		for (int i = 0; i < rows - 1; i++) {
			for (int j = 0; j < columns - 1; j++) {
				if (om.level [i, j] != null && om.level[i,j].gameObject.tag!="fixed_box" && om.level[i,j].gameObject.tag!="woodenBox_visible") {
					GameObject temp = om.level [i, j].gameObject;
					Destroy(om.level [i, j].gameObject);
					GameObject spawnedWoodenBox_invisible = Instantiate(woodenBox_invisible, new Vector3(i, 0, j), Quaternion.identity);
					Debug.Log ("Working!!!");
					om.level [i, j] = spawnedWoodenBox_invisible.gameObject;
					string tag = "woodenBox_" + (string)temp.tag;
					spawnedWoodenBox_invisible.gameObject.tag = tag;
					spawnedWoodenBox_invisible.transform.parent = level.transform;
				}
			}
		}
	}
}
