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

    public int DeliveredCount = 0;
    public int MaxDeliveredCount = 3;

    public void DeactivateDialog(string name)
    {
        var gameObject = GameObject.Find(name);
        var dialog = gameObject.GetComponent<DialogGUI>();

        dialog.DeactivateCurrentDialog();
    }

    public void AddDialog(string objectSemicolonDialog)
    {
        string[] splitted = objectSemicolonDialog.Split(';');
        DialogGUI dialogGui = GameObject.Find(splitted[0]).GetComponent<DialogGUI>();
        dialogGui.PendingDialogs.Add(splitted[1]);
    }

    public void Surrendered()
    {
        ToGameOver();
    }

    public void RemoveObject(string name)
    {
        GameObject.Find(name).SetActive(false);
    }

    public void ActivateDeliveredObject(string name)
    {
        Grid.SoundManager.PlaySingle(Grid.SoundManager.SuccessSound);
        DeliveredCount++;
        string deliveredName = name + "Delivered";
        GameObject delivered = GameObject.Find(deliveredName);

        if (delivered)
            delivered.SetActive(true);

        Grid.Inventory.RemoveObject(name);

        if (DeliveredCount == MaxDeliveredCount)
            AddDialog("MayorBroccoli;Epilogue");
    }

    void Start()
    {
        //Grid.EventHub.TriggerExampleIntegerEvent(5);
        Grid.EventHub.ExampleIntegerEvent += OnExampleIntegerEvent;
        Grid.EventHub.KillzoneTriggered += KillzoneTriggered;
        //Grid.EventHub.TriggerExampleIntegerEvent(15);
        MusicSingleton.Instance.SetActive(false);

    }

    void OnDestroy()
    {
        /* Unregister Events */
        Grid.EventHub.ExampleIntegerEvent -= OnExampleIntegerEvent;
        Grid.EventHub.KillzoneTriggered -= KillzoneTriggered;
    }


    void KillzoneTriggered()
    {
        Invoke("ToGameOver", 3);
    }

    public void ToGameOver()
    {
        SceneManager.LoadScene("GameOver");
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
