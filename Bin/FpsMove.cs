using Toolkit;
using UnityEngine;

namespace Core.Player.Bin
{
	public class FpsMove : MonoBehaviour
	{
		CharacterController c;
		Transform t;

		[Header("Movement")]
		public float speed = 4;
		[Range(1,14)]
		public float acceleration = 5;
		[Range(1,14)]
		public float deceleration = 5;
		public float apexModifier = 1.6f;
		
		[Header("Jump")]
		public float jumpHeight = 10.5f;
		public float gravityScale = 3.4f;
		public float jumpBuffer = 0.1f;

		Vector3 move;
		
		bool jumpInput;
		float bufferJump;
		const float gravity = -9.81f;
		float y;
		
		bool isGrounded => c.isGrounded;

		

		
		void Awake ()
		{
			t = transform;
			this.Fetch ( ref c );
		}

		void Update ()
		{
			
			
			Movement ();
			Jump ();
		}

		

		void Movement ()
		{
			// collect velocity
//			var _target = InputManager.input.Z * t.forward + InputManager.input.X * t.right;
			var _target = InputManager.input.Z * t.forward + InputManager.input.X * t.right;
			if ( _target.sqrMagnitude > 1 ) _target.Normalize(); // prevent diagonal speed

			
			var _isMoving = move.sqrMagnitude <= _target.sqrMagnitude; // acceleration vs deceleration
			var _apexModifier = isGrounded ? 1 : apexModifier; // apply apex modifier 
						
			// apply
			move = _isMoving ? Vector3.MoveTowards ( move, _target, acceleration * Time.deltaTime ) : Vector3.MoveTowards ( move, _target, deceleration * Time.deltaTime );
			c.Move ( Time.deltaTime * speed * _apexModifier * move );
		}

		void Jump ()
		{
			// Fix to problem with inconsistent of jumping is: put c.Move BEFORE checking isGrounded
			c.Move ( Time.deltaTime * y * Vector2.up );
			
			// GetJumpInput
			if ( InputManager.input.Jump )
			{
				if ( isGrounded )
					jumpInput = true;
				else
					bufferJump = jumpBuffer;

			}
			if ( isGrounded )
			{
				if ( jumpInput || bufferJump > 0 )
				{
					y = jumpHeight;
					
					bufferJump = 0;
					jumpInput = false;
					return;
				}
				y = -2;
			}
			else
				y += gravity * Time.deltaTime * gravityScale;

			if ( bufferJump > 0 ) bufferJump -= Time.deltaTime;
		}

		public void Teleport (Vector3 _pos)
		{
			c.enabled = false;
			transform.position = _pos;
			// ReSharper disable once Unity.InefficientPropertyAccess
			c.enabled = true;
		}

	}
	
}
