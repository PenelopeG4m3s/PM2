using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Prefabs")]
    public static GameManager instance;
    public GameObject playerControllerPrefab;
    public GameObject playerPawnPrefab;
    public GameObject enemyControllerSoldierPrefab;
    public GameObject enemyControllerPatrollerPrefab;
    public GameObject enemyControllerRunnerPrefab;
    public GameObject enemyControllerVulturePrefab;
    public GameObject enemyPawnPrefab;
    [Header("Up-to-date Lists")]
    public List<Pawn> tanks;
    public List<Controller> players;
    public List <ControllerAI> enemies;

    void Awake()
    {
        // Create our singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        // Create our up to date list objects (not just memory locations )
        tanks = new List<Pawn>();
        players = new List<Controller>();
    }

    void Start()
    {
        // Create our up to date list objects
        StartGame();

    }

    public void StartGame()
    {
        // Do everything that we need to start the game

        // Spawn the player
        SpawnPlayer();
        // Spawn enemies
        SpawnEnemies();

    }

    public void SpawnPlayer()
    {
        // Spawn a tank pawn (and store it in tanks)
        Pawn tempTankPawn = SpawnTank( playerPawnPrefab, Vector3.zero );

        // Spawn a player controller (and store it in player)
        Controller tempPlayerController = SpawnPlayerController(playerControllerPrefab);

        // Have the player possess the pawn
        tempPlayerController.Possess(tempTankPawn);
    }

    public void SpawnEnemies()
    {
        // Spawn a tank (and store it in tanks)
        Pawn tempTankPawn1 = SpawnTank( enemyPawnPrefab, new Vector3( 5.0f, 0.0f, -5.0f ) );
        Pawn tempTankPawn2 = SpawnTank( enemyPawnPrefab, new Vector3( 5.0f, 0.0f, 5.0f ) );
        Pawn tempTankPawn3 = SpawnTank( enemyPawnPrefab, new Vector3( -5.0f, 0.0f, 5.0f ) );
        Pawn tempTankPawn4 = SpawnTank( enemyPawnPrefab, new Vector3( -5.0f, 0.0f, -5.0f ) );

        // Spawn an enemy controller ( and store it in enemies)
        ControllerAI_Soldier tempTankController1 = SpawnEnemySoldierController( enemyControllerSoldierPrefab );
        ControllerAI_Patroller tempTankController2 = SpawnEnemyPatrollerController( enemyControllerPatrollerPrefab );
        ControllerAI_Runner tempTankController3 = SpawnEnemyRunnerController( enemyControllerRunnerPrefab );
        ControllerAI_Vulture tempTankController4 = SpawnEnemyVultureController( enemyControllerVulturePrefab );

        // Have the enemy possess the pawn
        tempTankController1.Possess( tempTankPawn1 );
        tempTankController2.Possess( tempTankPawn2 );
        tempTankController3.Possess( tempTankPawn3 );
        tempTankController4.Possess( tempTankPawn4 );
    }

    public Pawn SpawnTank( GameObject prefab, Vector3 position )
    {
        GameObject tempTankObject = Instantiate<GameObject>(prefab, position, Quaternion.identity);
        return tempTankObject.GetComponent<Pawn>();
    }

    public Controller SpawnPlayerController ( GameObject prefab )
    {
        GameObject tempPlayer = Instantiate<GameObject>( prefab, Vector3.zero, Quaternion.identity );
        return tempPlayer.GetComponent<Controller>();
    }

    public ControllerAI_Soldier SpawnEnemySoldierController ( GameObject prefab )
    {
        GameObject tempPlayer = Instantiate<GameObject>( prefab, Vector3.zero, Quaternion.identity );
        return tempPlayer.GetComponent<ControllerAI_Soldier>();
    }

    public ControllerAI_Patroller SpawnEnemyPatrollerController ( GameObject prefab )
    {
        GameObject tempPlayer = Instantiate<GameObject>( prefab, Vector3.zero, Quaternion.identity );
        return tempPlayer.GetComponent<ControllerAI_Patroller>();
    }

    public ControllerAI_Runner SpawnEnemyRunnerController ( GameObject prefab )
    {
        GameObject tempPlayer = Instantiate<GameObject>( prefab, Vector3.zero, Quaternion.identity );
        return tempPlayer.GetComponent<ControllerAI_Runner>();
    }

    public ControllerAI_Vulture SpawnEnemyVultureController ( GameObject prefab )
    {
        GameObject tempPlayer = Instantiate<GameObject>( prefab, Vector3.zero, Quaternion.identity );
        return tempPlayer.GetComponent<ControllerAI_Vulture>();
    }
}
