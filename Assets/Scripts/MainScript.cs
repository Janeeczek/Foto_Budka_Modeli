using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using Dummiesman;

public class MainScript : MonoBehaviour
{
    //PATHS
    string modelPath;
    string photoPath;
    static string inputPath = "/Input";    
    static string outputPath = "/Output";

    //GUI
    public Button backButton;
    public Button forwardButton;
    public Button photoButton;
    public Text errorText;

    //GAMEOBJECTS
    public GameObject parent;
    GameObject loadedObject;

    //VARIABLES
    List<string> modelsPaths;
    int currentModelCounter = -1;

    void Start()
    {
        //set paths
        modelPath = Application.dataPath + inputPath;
        photoPath = Application.dataPath + outputPath;


        //check if directories exist
        checkDirectories();


        //find only .obj files
        modelsPaths = getModels();


        //disable buttons if no model was found
        if(modelsPaths.Count == 0) {
            backButton.interactable = false;
            forwardButton.interactable = false;
            photoButton.interactable = false;
        }


        //add click listeners to buttons
        backButton.onClick.AddListener(() => backButtonCallBack());
        forwardButton.onClick.AddListener(() => forwardButtonCallBack());
        photoButton.onClick.AddListener(() => photoButtonCallBack());
    }
    private void backButtonCallBack() {
        //check if this is the first model in a list
        //if true, set counter to point on the last model
        //if false, set counter to point on the previous model
        if (currentModelCounter == 0) currentModelCounter = modelsPaths.Count -1;
        else currentModelCounter--;


        //process loading model from file
        loadModel(modelsPaths[currentModelCounter]);
    }

    private void forwardButtonCallBack() {
        //check if this is the last model in a list
        //if true, set counter to point on the first model
        //if false, set counter to point on the next model
        if (currentModelCounter==(modelsPaths.Count-1)) currentModelCounter = 0;
        else currentModelCounter++;


        //process loading model from file
        loadModel(modelsPaths[currentModelCounter]);
    }

    private void photoButtonCallBack() { 
        //process screenshot
        takePhoto();
    }

    private void loadModel(string path)  {
        //check if file still exists
        if (!File.Exists(path)){
            //if not, show error message
            errorText.gameObject.SetActive(true);
        } else {
            //if true, check if loadedObject has any model and destroy it
            if(loadedObject != null) Destroy(loadedObject);


            //load a new model from file
            loadedObject = new OBJLoader().Load(path);
            //reset parent position
            parent.transform.position = new Vector3(0,0,0);
            //set loadedObject to be a child of rotating object
            loadedObject.transform.parent = parent.transform;
            //reset loadedObject position
            loadedObject.transform.position = new Vector3(0,0,0);


            //if error message is visible, hide it
            if(errorText.IsActive()) errorText.gameObject.SetActive(false);
        }

    }
    private void takePhoto()  {
        //get time
        string dateNow = System.DateTime.Now.ToString("HH_mm_ss-dd.MM.yyyy");
        //hide gui buttons
        StartCoroutine(hideGUI());
        //take and save screenshot
        ScreenCapture.CaptureScreenshot(photoPath+"/screen_at_"+dateNow+ ".png");
    }

    IEnumerator hideGUI()
    {
        //hide gui buttons
        backButton.gameObject.SetActive(false);
        forwardButton.gameObject.SetActive(false);
        photoButton.gameObject.SetActive(false);


        //wait for 2 seconds
        yield return new WaitForSeconds(2);


        //show gui buttons
        backButton.gameObject.SetActive(true);
        forwardButton.gameObject.SetActive(true);
        photoButton.gameObject.SetActive(true);
    }
    private void checkDirectories() {
        //check if Input directory exist. If not create it.
        if(!Directory.Exists(modelPath))
        Directory.CreateDirectory(modelPath);

        //check if Output directory exist. If not create it.
        if(!Directory.Exists(photoPath))
        Directory.CreateDirectory(photoPath);
    }

    private List<string> getModels() {
        
        List<string> list = new List<string>();
        //iterate through all files in input directory and choose only .obj one
        foreach (string file in System.IO.Directory.GetFiles(modelPath))
        {
            if (file.Substring(file.Length - 4) == ".obj") {
                list.Add(file);
            }
        }
        
        return list;
    }
}
