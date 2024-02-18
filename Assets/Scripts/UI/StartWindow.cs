using UnityEngine;

using TMPro;
using UnityEngine.UI;

using CookingPrototype.Controllers;

namespace CookingPrototype.UI {
	public class StartWindow : MonoBehaviour {
		[SerializeField] private Image    goalBar            = null;
		[SerializeField] private Button   startButton        = null;
		[SerializeField] private TMP_Text ordersCountText    = null;

		private void Start() {
			SetOrderAmount();
			startButton.onClick.AddListener(StartGame);
		}

		void StartGame() {
			GameManger.StartGame();
			gameObject.SetActive(false);
		}
		
		void SetOrderAmount() {
			var gc = GameplayController.Instance;
			ordersCountText.text = $"{gc.TotalOrdersServed}/{gc.OrdersTarget}";
			goalBar.fillAmount = (float) gc.TotalOrdersServed / gc.OrdersTarget;
		}
	}
}

