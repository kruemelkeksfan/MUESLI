using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MUESLI.Controls.Strategy
	{
	public class CameraController : MonoBehaviour
		{
		[SerializeField] float movementSpeed = 0.0f;
		[SerializeField] float zoomSpeed = 0.0f;
		[SerializeField] float boostFactor = 1.0f;
		[SerializeField] float rotationSpeed = 1.0f;
		[SerializeField] Slider movementSpeedSlider = null;
		[SerializeField] Slider zoomSpeedSlider = null;
		[SerializeField] Slider rotationSpeedSlider = null;

		private float pitch = 0.0f;
		private float yaw = 0.0f;
		private float roll = 0.0f;
		private float zoom = 0.0f;

		private void Start()
			{
			Vector3 startrotation = transform.rotation.eulerAngles;
			pitch = startrotation.x;
			yaw = startrotation.y;
			roll = startrotation.z;

			UpdateMovementSpeed();
			UpdateZoomSpeed();
			UpdateRotationSpeed();
			}

		void Update()
			{
			// Boost on Shift
			float boost = 1.0f;
			if(Input.GetAxis("Boost") > 0.0f)
				{
				boost = boostFactor;
				}

			// Hide and lock Cursor when the Rotation Button is pressed and save Mouse Rotation
			if(Input.GetAxis("Rotate Camera") > 0.0f)
				{
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;

				yaw += Input.GetAxis("Mouse X") * rotationSpeed;
				pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
				}
			// Show and unlock Cursor on MMB Release
			else
				{
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				}

			// Get Input Directions
			Vector3 direction = new Vector3();
			if(Input.GetAxis("Vertical") > 0.0f)
				{
				direction += Vector3.forward;
				}
			if(Input.GetAxis("Horizontal") < 0.0f)
				{
				direction += Vector3.left;
				}
			if(Input.GetAxis("Vertical") < 0.0f)
				{
				direction += Vector3.back;
				}
			if(Input.GetAxis("Horizontal") < 0.0f)
				{
				direction += Vector3.right;
				}
			if(Input.GetAxis("Up") > 0.0f)
				{
				direction += Vector3.up;
				}
			if(Input.GetAxis("Down") < 0.0f)
				{
				direction += Vector3.down;
				}
			
			// Rotate and translate Camera
			transform.rotation = Quaternion.Euler(pitch, yaw, roll);
			transform.position += transform.rotation * direction.normalized * movementSpeed * boost;
			transform.position += transform.rotation * Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * boost;
			}

		public void UpdateMovementSpeed()
			{
			if(movementSpeedSlider != null && movementSpeedSlider.gameObject.activeSelf)
				{
				movementSpeed = movementSpeedSlider.value;
				}
			}

		public void UpdateZoomSpeed()
			{
			if(zoomSpeedSlider != null && zoomSpeedSlider.gameObject.activeSelf)
				{
				zoomSpeed = zoomSpeedSlider.value;
				}
			}

		public void UpdateRotationSpeed()
			{
			if(rotationSpeedSlider != null && rotationSpeedSlider.gameObject.activeSelf)
				{
				rotationSpeed = rotationSpeedSlider.value;
				}
			}
		}
	}