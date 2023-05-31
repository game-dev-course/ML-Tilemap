using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine.Tilemaps;

public class WarriorAgent : Agent
{
    [SerializeField] private GameObject player;
    [SerializeField] AllowedTiles allowedTiles = null;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private float speed = 2f;
    private EnvController envController;
    private bool canStep = true;


    private void Start()
    {
        envController = FindObjectOfType<EnvController>();
    }

    private void Update()
    {
        Debug.Log("Current warrior pos: " + transform.position);
    }

    public override void OnEpisodeBegin()
    {
        // Debug.Log("EPISODE BEGIN!");
        envController.ResetEnv();
        
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        Debug.Log("HERUISTIC BEGIN!");
    }
    
    public override void CollectObservations(VectorSensor sensor)
    {
        // Debug.Log("OBSERVATION BEGIN!");

        sensor.AddObservation(transform.position);
        sensor.AddObservation(player.transform.position);
    }

    IEnumerator StepDelay()
    {
        float timeBetweenSteps = 1 / speed;
        canStep = false;
        yield return new WaitForSeconds(timeBetweenSteps);
        canStep = true;
    }

    void MakeOneStepTowardsTheTarget(int move)
    {
        int up = 0, down = 1, left = 2, right = 3;
        // Debug.Log("CURRENT POS: " + transform.position);

        if (move == up)
        {
            Debug.Log("UP");
            transform.position += new Vector3(0, 1, 0);
        }
        else if (move == down)
        {
            Debug.Log("DOWN");
            transform.position += new Vector3(0, -1, 0);
        }
        else if (move == left)
        {
            Debug.Log("LEFT");
            transform.position += new Vector3(-1, 0, 0);
        }
        else
        {
            Debug.Log("RIGHT");
            transform.position += new Vector3(1, 0, 0);
        }
        
    }
    
    public override void OnActionReceived(ActionBuffers actions)
    {
        Debug.Log("ACTION RECEIVED!");
        int move = actions.DiscreteActions[0];

        if (canStep)
        {
            MakeOneStepTowardsTheTarget(move);
            StartCoroutine(StepDelay());
        }

        TileBase currPlayerTile = TileOnPosition(gameObject.transform.position);
        if (!allowedTiles.Contain(currPlayerTile))
        {
            Debug.Log("END EPISODE");
            SetReward(-1);
            EndEpisode();
        }
        else
        {
            SetReward(0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collusion!");
            SetReward(5);
            EndEpisode();
        }
    }
    
    private TileBase TileOnPosition(Vector3 worldPosition) {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        return tilemap.GetTile(cellPosition);
    }

    
}
