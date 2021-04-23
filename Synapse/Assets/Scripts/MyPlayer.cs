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
    public LayerMask interactMask;
    
    private Vector3 _playerVelocity;
    private bool _isGrouded;
    internal bool isHoldingObject = false;
    public GameObject cam;//pour pouvoir désactiver la camera si jamais elle n'appartient pas au joueur

    private GameObject holding = null;
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
        if (photonView.IsMine)
        {
            Controls();
            Interactions();
        }
        else if (cam.activeSelf)//si ce n'est pas notre joueur et si sa camera est activée
            cam.SetActive(false);
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

    private void Interactions()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        if (Input.GetKey(KeyCode.E) && Physics.Raycast(ray, out hitInfo, 3.5f, interactMask))
        {
            if (hitInfo.collider.GetComponent<Interactions>().Interraction(transform, cam.transform))
            {
                Debug.Log("test2");
                holding = hitInfo.collider.gameObject;
                isHoldingObject = true;
            }
        }

        RaycastHit info;
        Physics.Raycast(ray, out info, 3.5f);
        
        if (isHoldingObject && Input.GetMouseButtonDown(0))
        {
            isHoldingObject = false;
            holding.GetComponent<Rigidbody>().isKinematic = false;
            holding.transform.parent = null;
            if (info.collider == null)
                holding.transform.position = cam.transform.position + ray.direction * 3.5f;
            else
                holding.transform.position = info.point;
            holding = null;
        }
    }
}
