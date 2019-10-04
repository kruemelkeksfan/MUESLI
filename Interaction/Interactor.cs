using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUESLI.Interaction
	{
	public class Interactor : MonoBehaviour
		{
		[SerializeField] private GameObject interactionHintPrefab = null;
		private Interactable[] interactables = null;
		private bool released = true;
		private bool interaction = false;
		private GameObject interactionHint = null;

		private void Start()
			{
			interactables = GameObject.FindObjectsOfType<Interactable>();
			interactionHint = GameObject.Instantiate(interactionHintPrefab);
			}

		private void FixedUpdate()
			{
			foreach(Interactable interactable in interactables)
				{
				if(Vector2.Distance(interactable.transform.position, transform.position) < interactable.GetTriggerDistance())
					{
					if(released && !interaction && Input.GetAxis("Interact") > 0.0f)
						{
						released = false;
						interaction = true;
						interactionHint.SetActive(false);
						interactable.Interact(gameObject);
						}
					else if(!interaction)
						{
						interactionHint.SetActive(true);
						}
					}
				else
					{
					if(interaction)
						{
						interaction = false;
						interactable.StopInteract(gameObject);
						}
					interactionHint.SetActive(false);
					}

				if(released && interaction && Input.GetAxis("Interact") > 0.0f)
					{
					released = false;
					interaction = false;
					interactable.StopInteract(gameObject);
					}
				else if(Input.GetAxis("Interact") <= 0.0f)
					{
					released = true;
					}
				}
			}
		}
	}
