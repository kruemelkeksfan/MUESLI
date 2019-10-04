using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
	{
	[SerializeField] private float movementSpeed = 0.0f;
	[SerializeField] private float rotationSpeed = 0.0f;
	[Tooltip("Maximum look down Angle, Front is 0/360 Degrees, straight down 90 Degrees")]
	[SerializeField] private float maxLookDown = 0.0f;
	[Tooltip("Maximum look up Angle, Front is 0/360 Degrees, straight up 270 Degrees")]
	[SerializeField] private float maxLookUp = 0.0f;
	[SerializeField] private float jumpStrength = 0.0f;
	private bool grounded = true;
	private Rigidbody rigidbody = null;
	private Transform head = null;
	private Vector3 movement = Vector3.zero;

	private void Start()
		{
		rigidbody = gameObject.GetComponent<Rigidbody>();

		if(transform.childCount > 0 && transform.GetChild(0).name == "Head")
			{
			head = transform.GetChild(0);
			}
		}

	private void FixedUpdate()
		{
		// Rotation
		Vector3 rotation = transform.rotation.eulerAngles;

		if(head != null)
			{
			rotation.x = head.rotation.eulerAngles.x;
			}

		rotation.x += -Input.GetAxis("Mouse Y") * rotationSpeed;
		rotation.y += Input.GetAxis("Mouse X") * rotationSpeed;
		rotation.z = 0.0f;

		if(rotation.x < 180 && rotation.x > maxLookDown)
			{
			rotation.x = maxLookDown;
			}
		else if(rotation.x > 180 && rotation.x < maxLookUp)
			{
			rotation.x = maxLookUp;
			}

		if(head != null)
			{
			head.rotation = Quaternion.Euler(new Vector3(rotation.x, rotation.y, 0.0f));
			transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation.y, 0.0f));
			}
		else
			{
			transform.rotation = Quaternion.Euler(rotation);
			}

		// Movement and jumping is only possible when having Ground Contact, else the last Input is applied again
		if(grounded)
			{
			// Movement
			movement = transform.rotation * new Vector3(Input.GetAxis("Horizontal") * movementSpeed, 0.0f, Input.GetAxis("Vertical") * movementSpeed);
			transform.Translate(movement, Space.World);
			
			// Jumping
			if(Input.GetAxis("Jump") > 0)
				{
				rigidbody.AddForce(transform.up * jumpStrength, ForceMode.Impulse);
				}
			}
		else
			{
			// Jump Movement
			transform.Translate(movement, Space.World);
			movement *= 1.0f - rigidbody.drag;
			}
		}

	private void OnTriggerEnter(Collider other)
		{
		grounded = true;
		}

	private void OnTriggerExit(Collider other)
		{
		grounded = false;
		}
	}
