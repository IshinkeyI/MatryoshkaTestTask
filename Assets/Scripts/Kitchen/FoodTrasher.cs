using UnityEngine;

using JetBrains.Annotations;

namespace CookingPrototype.Kitchen {
	[RequireComponent(typeof(FoodPlace))]
	public sealed class FoodTrasher : MonoBehaviour {

		FoodPlace _place = null;
		float     _timer = 0f; // Так и не понял зачем здесь _timer
		int       _tapCount = 0;

		void Start() {
			_place = GetComponent<FoodPlace>();
			_timer = Time.realtimeSinceStartup;
		}

		/// <summary>
		/// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
		/// </summary>
		[UsedImplicitly]
		public void TryTrashFood() {
			if (_place.IsFree || _place.CurFood.CurStatus != Food.FoodStatus.Overcooked ) return;

			if ( ++_tapCount < 2 ) return;

			_place.FreePlace();
			_tapCount = 0;
		}
	}
}
