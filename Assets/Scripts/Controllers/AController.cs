using UnityEngine;

namespace CookingPrototype.Controllers {
	public abstract class AController : MonoBehaviour {
		public abstract void Init();
		public abstract void OnUpdate();
	}
}