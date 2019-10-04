using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUESLI.Controls.TopDown
	{
	public class CameraController : MonoBehaviour
		{
		[SerializeField] private GameObject focusObject = null;
		[SerializeField] private float maxDistance = 1.0f;
		[SerializeField] private float cameraZ = -10.0f;

		private void FixedUpdate()
			{
			Vector2 distance = focusObject.transform.position - transform.position;
			float newX = transform.position.x;
			float newY = transform.position.y;

			if(Mathf.Abs(distance.x) > maxDistance)
				{
				if(distance.x >= 0.0f)
					{
					newX += distance.x - maxDistance;
					}
				else
					{
					newX += distance.x + maxDistance;
					}
				}
			if(Mathf.Abs(distance.y) > maxDistance)
				{
				if(distance.y >= 0.0f)
					{
					newY += distance.y - maxDistance;
					}
				else
					{
					newY += distance.y + maxDistance;
					}
				}

			transform.position = new Vector3(newX, newY, cameraZ);
			}
		}
	}