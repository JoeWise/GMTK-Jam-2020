using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEnvironment : MonoBehaviour
{
    public bool catVisible;

    public GameObject[] cats;

    private void OnEnable()
    {
        StartCoroutine("CycleCats");
        catVisible = false;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        catVisible = false;

        foreach(GameObject g in cats)
        {
            g.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CycleCats()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));

            int i = Random.Range(0, 3);

            cats[i].SetActive(true);
            catVisible = true;

            yield return new WaitForSeconds(Random.Range(1.5f, 3f));

            cats[i].SetActive(false);
            catVisible = false;
        }
    }
}
