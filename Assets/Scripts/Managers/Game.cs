using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    private GameState currentGameState;
    public GameState State => currentGameState;

    [SerializeField]
    public Player player;
    
    // Start is called before the first frame update
    void Start() {
        currentGameState = GameState.PrePlan;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGameState == GameState.PrePlan) {
            currentGameState = GameState.Plan;
        } else if (currentGameState == GameState.PrePlan) {
            // enable actions for user
        }
    }
    
    public enum GameState {
        PrePlan, // draw
        Plan, // buy, place, sell, scrap activation
        Combat // watch auto combat
    }
}
