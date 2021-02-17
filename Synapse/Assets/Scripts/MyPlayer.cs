using UnityEngine;
using Photon.Pun;

public class MyPlayer : MonoBehaviourPun
{
    private TextMesh Caption = null;

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float heightJump = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 _playerVelocity;
    private bool _isGrouded;
    public Camera cam;//pour pouvoir supprimer la camera si jamais elle n'appartient pas au joueur

    private void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).name == "Player Name" && photonView.IsMine)
            {
                Caption = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                Caption.text = PhotonNetwork.NickName;
            }
        }
    }
    private void Update()
    {
        if (!photonView.IsMine)
            Destroy(cam);
        else
        {
            Controls();
        }
    }

    private void Controls()
    {
        _isGrouded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        _playerVelocity.y += gravity * Time.deltaTime;

        if (_isGrouded && _playerVelocity.y < 3)
        {
            _playerVelocity.y = 0f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * (speed * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.Space) && _isGrouded)
        {
            _playerVelocity.y += Mathf.Sqrt(heightJump * -2f * gravity);
        }

        controller.Move(_playerVelocity * Time.deltaTime);
    }

    /*
    private void Controls()
    {
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");
        this.transform.Translate(Vector3.forward * vert * Movespeed * Time.deltaTime);
        this.transform.localRotation *= Quaternion.AngleAxis(horz * Turnspeed * Time.deltaTime, Vector3.up);
    }*/
}
