using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour {
        public GameObject myPrefab;
    public string _WebsiteURL = "http://infomgmt.azurewebsites.net/tables/CardMovement?zumo-api-version=2.0.0";

    void Start () {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        CardMovement[] cardmovements = JsonReader.Deserialize<CardMovement[]>(jsonResponse);

        //----------------------
        //YOU WILL NEED TO DECLARE SOME VARIABLES HERE SIMILAR TO THE CREATIVE CODING TUTORIAL
        int totalCubes = cardmovements.Length;
        int totalDistance = 5;
        int i = 0;
        //----------------------

        //We can now loop through the array of objects and access each object individually
        foreach (CardMovement cardmovement in cardmovements )
        {
            //Example of how to use the object
            Debug.Log("This task is: " + cardmovement.Task);
            float perc = i / (float)totalCubes;
            i++;
            float sin = Mathf.Sin(perc * Mathf.PI / 2);
            float x = 1.0f + sin * totalDistance;
            float y = 5.0f;
            float z = 0.0f;
            //----------------------
            //YOUR CODE TO INSTANTIATE NEW PREFABS GOES HERE
            GameObject newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
            newCube.GetComponent<CubeScript>().SetSize((1.0f - perc)); 
            newCube.GetComponent<CubeScript>().RotateSpeed = .2f + perc*perc; 
            
                

            //----------------------
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
