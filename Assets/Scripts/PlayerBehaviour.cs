using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
	public bool IsPaused { get; private set; }

	private void Awake() {
		GameManager.OnGameStateChanged += Pause;
	}

	private void OnDestroy() {
		GameManager.OnGameStateChanged -= Pause;
	}

	private void OnGUI() {
		Event e = Event.current;
		switch (e.type)
		{
			case EventType.KeyDown:
				if (e.keyCode == KeyCode.Escape) {
					if (IsPaused == true) { GameManager.Instance.UpdateGameState(GameState.GameRunning); }
					else { GameManager.Instance.UpdateGameState(GameState.GamePaused); }
				}
				break;
			default:
				break;
		}
	}

	public void Pause(GameState state) {
		IsPaused = (state == GameState.GamePaused);
	}
}
