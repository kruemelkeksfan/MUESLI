using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUESLI.Controls.TopDown
	{
	public class PlayerController : MonoBehaviour
		{
		[SerializeField] private float movementSpeed = 0.0f;
		[SerializeField] private float rotationSpeed = 0.0f;
		[SerializeField] private Camera camera = null;

		private void FixedUpdate()
			{
			transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f).normalized * movementSpeed;

			// Swap forward and upwards, because LookRotation() tries to align forward with Z-Axis
			// Would be safer if Input.mouseposition.z would be set to 0.0f
			Quaternion lookDirection = Quaternion.LookRotation(Vector3.forward, camera.ScreenToWorldPoint(Input.mousePosition) - transform.position);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, lookDirection, rotationSpeed);
			}
		}
	}