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

    void Start()
    {
        //Grid.EventHub.TriggerExampleIntegerEvent(5);
        Grid.EventHub.ExampleIntegerEvent += OnExampleIntegerEvent;
        Grid.EventHub.KillzoneTriggered += KillzoneTriggered;
        //Grid.EventHub.TriggerExampleIntegerEvent(15);

    }

    void OnDestroy()
    {
        /* Unregister Events */
        Grid.EventHub.ExampleIntegerEvent -= OnExampleIntegerEvent;
        Grid.EventHub.KillzoneTriggered -= KillzoneTriggered;
    }


    void KillzoneTriggered()
    {
        Debug.Log("Killzoned!");
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
