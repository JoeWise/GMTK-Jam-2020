using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfieldManager : MonoBehaviour
{
    GameObject curr_playfield;
    GameObject next_playfield;

    public GameObject starting_playfield;
    public GameObject[] playfield_pool;

    private Vector3 start_pos;

    // Start is called before the first frame update
    void Start()
    {
        curr_playfield = starting_playfield;

        start_pos = new Vector3(0, curr_playfield.transform.position.y - 25, 0);

        next_playfield = Instantiate(playfield_pool[1], start_pos, playfield_pool[1].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (!(curr_playfield.GetComponent<Renderer>().isVisible))
        {
            curr_playfield.SetActive(false);

            curr_playfield = next_playfield;

            start_pos = new Vector3(0, curr_playfield.transform.position.y - 25, 0);

            next_playfield = Instantiate(playfield_pool[Random.Range(0, playfield_pool.Length)], start_pos, next_playfield.transform.rotation);
        }
    }
}
