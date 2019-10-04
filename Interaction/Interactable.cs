using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUESLI.Interaction
	{
	public abstract class Interactable : MonoBehaviour
		{
		[SerializeField] private float triggerDistance = 1.0f;

		public abstract void Interact(GameObject trigger);
		public abstract void StopInteract(GameObject trigger);

		public float GetTriggerDistance()
			{
			return triggerDistance;
			}
		}
	}