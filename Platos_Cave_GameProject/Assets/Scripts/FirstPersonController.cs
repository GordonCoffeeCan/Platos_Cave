using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {
	public float speed = 5;
	public float rotationSpeed = 8;

	private Transform _mainCamera;
	private Transform _weaponPivot;
	private Vector3 _moveDirection;
	private float _gravity = 20;
	private Transform _transfrom;

	private CharacterController _characterController;

	// Use this for initialization
	void Start () {
		_mainCamera = GameObject.Find ("MainCamera").transform;
		_transfrom = this.transform;
		_weaponPivot = _transfrom.FindChild ("WeaponPivot");
		_moveDirection = Vector3.zero;
		_characterController = this.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Quaternion _controllerTargetRotation = Quaternion.Euler (0, _mainCamera.eulerAngles.y, 0);
		Quaternion _pivotTargetRotation = Quaternion.Euler (_mainCamera.eulerAngles.x, _mainCamera.eulerAngles.y, 0);
		_transfrom.rotation = Quaternion.Slerp (_transfrom.rotation, _controllerTargetRotation, rotationSpeed * Time.deltaTime);
		_weaponPivot.rotation = Quaternion.Slerp (_weaponPivot.rotation, _pivotTargetRotation, rotationSpeed * Time.deltaTime);
		if (_characterController.isGrounded) {
			_moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			_moveDirection = _transfrom.TransformDirection (_moveDirection);
			_moveDirection *= speed;
		}
		_moveDirection.y -= _gravity * Time.deltaTime;
		_characterController.Move (_moveDirection * Time.deltaTime);
		_mainCamera.position = new Vector3(_transfrom.position.x, _transfrom.position.y + 1, _transfrom.position.z);
	}
}
