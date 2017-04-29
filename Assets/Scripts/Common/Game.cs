using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public bool IsDialogActive
    {
        get
        {
            return VIDE_Data.isLoaded;
        }
    }
    //Stores all (globally) relevant game variables


    public void UpdateItem(string name, bool val)
    {

    }

    public void DeactivateDialog(string name)
    {
        var gameObject = GameObject.Find(name);
        var dialog = gameObject.GetComponent<DialogGUI>();
        
        dialog.isDeactivated = true;
    }

    public void Surrendered()
    {
        Debug.Log("Surrendered");
    }

    void Start()
    {
        //Grid.EventHub.TriggerExampleIntegerEvent(5);
        Grid.EventHub.ExampleIntegerEvent += OnExampleIntegerEvent;
        //Grid.EventHub.TriggerExampleIntegerEvent(15);

    }

    void OnDestroy()
    {
        /* Unregister Events */
        Grid.EventHub.ExampleIntegerEvent -= OnExampleIntegerEvent;
    }

    public void OnExampleIntegerEvent(int value)
    {
        Debug.Log("ExampleIntegerEvent ... " + value);
    }

    void Update()
    {
        /*if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("Title");
		}*/
    }


}
