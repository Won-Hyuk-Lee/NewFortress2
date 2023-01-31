using Photon.Pun;
using UnityEngine;

public class Tank : MonoBehaviourPunCallbacks
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    public PhotonView PV;
    [SerializeField] Transform FirePosL;
    [SerializeField] Transform FirePosR;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        PV = photonView;
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            Move();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(PV.IsMine)
            {
                Fire();
            }
        }

    }

    void Move()
    {

        float axis = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(axis * Time.deltaTime * 7, 0, 0));
        if (axis != 0) photonView.RPC("FlipXRPC", RpcTarget.AllBuffered, axis);

    }

    [PunRPC]
    void FlipXRPC(float axis)
    {
        sr.flipX = (axis == -1);
    }

    [PunRPC]
    void Fire()
    {
        if (sr.flipX == false)
        {
            PhotonNetwork.Instantiate("Bullet", FirePosR.position, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate("Bullet", FirePosL.position, Quaternion.identity);
        }
        
    }

}
