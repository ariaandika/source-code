using Core.Manager;
using UnityEngine;

namespace Core.Player.Bin
{
	public class Interaction : MonoBehaviour
	{
		[SerializeField] float interactionDistance = 2;

		public static int deviceSelected = 0;

		static Transform t;
		static FpsMove move;

		void Awake ()
		{
			t = transform.root;
			move = GetComponentInParent<FpsMove> ();
		}


		void Update ()
		{
			Interacting();
		}



		public void Interacting ()
		{
			bool isInteracting;
			
			if ( InputManager.input.Interact )
				isInteracting = true;
			else if ( InputManager.input.changeWorld )
				isInteracting = false;
			else return;

			// Start ray casting if one of button pressed 
			var ray = CamFps.cam.ScreenPointToRay ( Input.mousePosition );
			if ( !Physics.Raycast ( ray, out var hitInfo, interactionDistance ) ) return;

			
			// Interacting
			if ( isInteracting && hitInfo.transform.TryGetComponent ( out IInteractable _interact ) )
			{
				_interact.OnInteract ();
			}
			// Selecting object
			else if (!isInteracting && hitInfo.transform.TryGetComponent ( out IDevice _target ))
			{
				// ReSharper disable once SwitchStatementMissingSomeCases
				
			}
		}

		
	}

}