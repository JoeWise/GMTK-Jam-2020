using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = player.transform.localPosition.y - this.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, player.localPosition.y - offset, this.transform.localPosition.z);
    }
}
