using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
public class Mod1_Task1_timer : MonoBehaviour
{
    private bool timerStarted = false;
    private bool Finish_task1 = false;
    private float startTime = 0f;
    private float elapsedTime = 0f;
    [SerializeField] Text timer1;


    public XRBaseInteractable interactable; // Reference to your interactable object

    private void OnEnable()
    {
        interactable.selectExited.AddListener(OnSelectExited);
    }

    private void OnDisable()
    {
        interactable.selectExited.RemoveListener(OnSelectExited);
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        Finish_task1 = true;
        // This method is called when the user stops interacting with the interactable.
        Debug.Log("Select exited: " + args.interactor.name);
        // Add your custom logic here.
    }
    public void StartTimer()
    {
        if (!timerStarted)
        {
            timerStarted = true;
            startTime = Time.time;
        }
    }

    public void StopTimer()
    {
        timerStarted = false;
        elapsedTime = 0f;
    }

    private void Update()
    {

        if (Task1_mod1.allTorusClose && Finish_task1)
            StopTimer();

        if (timerStarted)
        {
            elapsedTime = Time.time - startTime;
            timer1.text = "Timer: " + elapsedTime.ToString("F1") + "s";
          
        }

    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}
