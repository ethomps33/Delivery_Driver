using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    //indicating if the car has the package or not
    bool hasPackage;
    //the count of the amount of packages the car has
    public int count = 0;
    //how quickly the package gameobjects will be destroyed after being picked up
    [SerializeField] float destroyTime = 1;
    //color of the car depending on how many packes the car has
    [SerializeField] Color32 noPackageColor = new Color32 (245, 244, 244, 255);
    [SerializeField] Color32 onePackageColor = new Color32 (88, 241, 6, 255);
    [SerializeField] Color32 twoPackageColor = new Color32 (255, 201, 1, 255);
    [SerializeField] Color32 threePackageColor = new Color32 (255, 98, 1, 255);
    [SerializeField] Color32 fourPackageColor = new Color32 (255, 24, 1, 255);
    //the color the package will change to once the car is approching
    Color32 gettingClose = new Color32 (88, 241, 6, 255);
    //instance of type spriterenderer used to change color of the car
    SpriteRenderer spriteRenderer;
    //an array of gameobjects of type package
    string[] packages = {"Package", "Package2", "Package3", "Package4","Package5"};
    //instance of type spriterenderer to be used to change the package color
    SpriteRenderer packageColor;
    
    void Awake() {
        // packageColor = GameObject.Find("Package").GetComponent<SpriteRenderer>();
        
        // Debug.Log(packageColor);
    }    

    void Start() {
        
    }
    

    //action to be taken when car collides with a gameobject that has rigidbody enabled
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Welp, the insruance is gonna go up now.");
    }
    //action to be taken when the car passes through a collider that is a trigger
    void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log(packageColor);
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // foreach (string package in packages){
        //     packageColor = GameObject.Find(package).GetComponent<SpriteRenderer>();
        //     if (other.tag == "Area") {
        //         packageColor.color = gettingClose;
        //         Debug.Log("We're getting close!");
        //         break;      
        //     }
        // }
        //if the tag of the object is Package and the car does not have a package
        if (other.tag == "Package" && !hasPackage) {
            
            Debug.Log("Got the goods in the bag!");
            //has package will change to true 
            hasPackage = true;
            //count of packages will increase by one
            count ++;
            //color of the car will change to green
            spriteRenderer.color = onePackageColor;
            //the package that was picked up will be destroyed
            Destroy(other.gameObject, destroyTime);
        } 
        //if the tog of the object is Package and the car already has a package
        else if (other.tag == "Package" && hasPackage) {
            
            Debug.Log("Got multiple buns in the oven! Multiple buns people!");
            hasPackage = true;
            //count of packages will increase by one
            count ++;
            //color of the car will change to yellow
            spriteRenderer.color = twoPackageColor;
            //the package that was picked up will be destroyed
            Destroy(other.gameObject, destroyTime);

            //if the count is equal to 3
            if (count == 3) {
                spriteRenderer.color = threePackageColor;
                Debug.Log("We're getting a little heavy.");
            }
            //if the count is equal to 4
            else if (count == 4) {
                spriteRenderer.color = fourPackageColor;
                Debug.Log("We have to make a delivery soon or the car will stop!");
            }
            //if the count is equal to 5
            else if (count == 5) {
                spriteRenderer.color = noPackageColor;
                Debug.Log("Drats! The car brokedown because the packages were too heavy!");
        }
        } 

        //if the tag of the gameobject is Customer and the car has at least one package
        if (other.tag == "Customer" && hasPackage) {

            Debug.Log("I've got " +(count)+ " coming your way!");
            hasPackage = false;     
            //count of the packages will be set to 0
            count = 0;
            //the car color will be changed back to it's original color
            spriteRenderer.color = noPackageColor;
        }      

       
    }
}
