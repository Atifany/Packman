using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public GameState State;

	public static event Action<GameState> OnGameStateChanged;

	private void Awake() {
		Instance = this;
	}

	private void Start() {
		UpdateGameState(GameState.GamePaused);
	}

	public void UpdateGameState(GameState newState) {
		State = newState;

		Debug.Log("UpodateGameState called");

		switch (newState)
		{
			case GameState.GamePaused:
				break;
			case GameState.GameRunning:
				break;
			case GameState.Lose:
				break;
			case GameState.Win:
				break;
			default:
				break;
		}

		OnGameStateChanged?.Invoke(newState); // if not ?.Invoke then if no subscribers = exception
	}
}

public enum GameState {
	GamePaused,
	GameRunning,
	Lose,
	Win
}
