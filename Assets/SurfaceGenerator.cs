using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SurfaceGenerator : MonoBehaviour {

    public GameObject surfaceCreator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var children = new List<GameObject>();
        foreach (Transform child in transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));
    }

    public void clearAll() {

    }

    public void generate() {
        GameObject part = (GameObject)Instantiate(surfaceCreator);

        part.transform.parent = this.transform;
        part.transform.position = new Vector3(part.transform.position.x,
                                                     part.transform.position.y,
                                                     part.transform.position.z);

        part.GetComponent<SurfaceCreator>().setOffsset(Random.Range(1, 100), Random.Range(1, 100), Random.Range(1, 100));
    }

    void OnGUI() {
        if (GUI.Button(new Rect(110, 10, 100, 50), "Generate")) {
            clearAll();
            generate();
        }
    }
}
