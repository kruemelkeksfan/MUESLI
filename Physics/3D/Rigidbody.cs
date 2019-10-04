using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUESLI.Physics.ThreeD
	{
	public class Rigidbody : MonoBehaviour
		{
		[SerializeField] private float mass = 1.0f;
		[SerializeField] private float drag = 0.0f;
		private Vector3 velocity = Vector3.zero;

		void FixedUpdate()
			{
			transform.position += velocity;
			velocity *= 1.0f - drag;
			}

		public void ApplyAccelaration(Vector3 acceleration)
			{
			this.velocity += acceleration;
			}

		public void ApplyForce(Vector3 force)
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