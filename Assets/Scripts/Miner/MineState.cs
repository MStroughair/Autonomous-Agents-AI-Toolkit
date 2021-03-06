﻿using UnityEngine;

public sealed class MineState : State<Miner> {
	
	static readonly MineState instance = new MineState();
	
	public static MineState Instance {
		get {
			return instance;
		}
	}
	
	static MineState () {}
	private MineState () {}
	
	public override void Enter (Miner agent) {
        if (agent.destination == eLocation.UNSET)
            agent.location = eLocation.Mine;
        agent.destination = eLocation.Mine;
		Debug.Log("Bob is mining...");
	}
	
	public override void Execute (Miner agent) {
		agent.Mine();
		//Debug.Log("Mining Gold. Total Mined: " + Miner.totalGold + " unit" + (Miner.totalGold > 1 ? "s" : "") + "...");
        if (Miner.totalGold > 7)
            agent.ChangeState(BankingState.Instance);
	}
	
	public override void Exit (Miner agent) {
		Debug.Log("...Enough mining for one day!");
        int stench = Random.Range(1, 3);
        Agent.TriggerSmellEvent(agent, stench);
	}
}
