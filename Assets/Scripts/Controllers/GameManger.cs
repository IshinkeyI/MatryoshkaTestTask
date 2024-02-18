using UnityEngine;

using System;
using System.Collections.Generic;

namespace CookingPrototype.Controllers {
	public class GameManger : MonoBehaviour {
		[SerializeField] private List<AController> controllers;

		public static Action OnUpdate;
		public static bool IsGameStarted;
		public static GameManger Instance { get; private set; }
		
		void Awake() {
			Instance = this;
		}

		void Start() {
			InitGame();
		}

		void Update() {
			if(IsGameStarted) {
				OnUpdate?.Invoke();
			}
		}

		private static void InitGame() {
			foreach ( var controller in Instance.controllers ) {
				controller.Init();
			}
		}
		
		public static void StartGame() {
			foreach ( var controller in Instance.controllers ) {
				OnUpdate += controller.OnUpdate;
			}

			IsGameStarted = true;
		}

		public static void EndGame() {
			IsGameStarted = false;
		}
		
	}
}