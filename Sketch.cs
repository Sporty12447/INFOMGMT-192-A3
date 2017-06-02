using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour {
        public GameObject myPrefab;
    public string _WebsiteURL = "http://infomgmt.azurewebsites.net/tables/products?zumo-api-version=2.0.0";

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
        Product[] products = JsonReader.Deserialize<Product[]>(jsonResponse);

        //----------------------
        //YOU WILL NEED TO DECLARE SOME VARIABLES HERE SIMILAR TO THE CREATIVE CODING TUTORIAL
       /*nmer653*/ int totalCubes = 8;/*nmer653*/
        /*nmer653*/int totalDistance = 5;/*nmer653*/
        int i = 0;
        //----------------------

        //We can now loop through the array of objects and access each object individually
        foreach (Product product in products)
        {
            //Example of how to use the object
            Debug.Log("This products name is: " + product.ProductName);
            float perc = i / (float)totalCubes;
            i++;
            /*nmer653*/float x = 3.0f;
            float y = 5.0f;
            float z = 0.0f;/*nmer653*/
            //----------------------
            //YOUR CODE TO INSTANTIATE NEW PREFABS GOES HERE
            GameObject newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
            /*nmer653*/newCube.GetComponent<CubeScript>().SetSize(perc); /*nmer653*/
           /*nmer653*/ newCube.GetComponent<CubeScript>().RotateSpeed = perc; /*nmer653*/
            
                

            //----------------------
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
