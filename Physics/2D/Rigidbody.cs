using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUESLI.Physics.TwoD
	{
	public class Rigidbody : MonoBehaviour
		{
		[SerializeField] private float mass = 1.0f;
		[SerializeField] private float drag = 0.0f;
		private Vector2 velocity = Vector2.zero;

		void FixedUpdate()
			{
			transform.position += new Vector3(velocity.x, velocity.y, 0.0f);
			velocity *= 1.0f - drag;
			}

		public void ApplyAccelaration(Vector2 acceleration)
			{
			this.velocity += acceleration;
			}

		public void ApplyForce(Vector2 force)
			{
			if(mass > 0.0f)
				{
				this.velocity += force / mass;
				}
			else
				{
				Debug.LogError("Mass must be greater than 0 to apply Force!");
				}
			}
		}
	}