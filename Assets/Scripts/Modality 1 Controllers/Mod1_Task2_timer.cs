using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
public class Mod1_Task2_timer : MonoBehaviour
{
    private bool timerStarted = false;
    private bool Finish_task2 = false;
    private float startTime = 0f;
    private float elapsedTime = 0f;
    [SerializeField] Text timer1;
    bool Timer2 = true;
  
    public XRBaseInteractable[] interactables; // References to your interactable objects
 


    private void OnEnable()
    {
        foreach (var interactable in interactables)
        {
            interactable.selectEntered.AddListener(OnSelectEntered);
            interactable.selectExited.AddListener(OnSelectExited);
 
        }
    }

    private void OnDisable()
    {
        foreach (var interactable in interactables)
        {
            interactable.selectEntered.RemoveListener(OnSelectEntered);
            interactable.selectExited.RemoveListener(OnSelectExited);
        }
    }



    private void OnSelectExited(SelectExitEventArgs args)
    {
        Finish_task2 = true;
        // This method is called when the user stops interacting with an interactable.
        Debug.Log("Select exited: " + args.interactor.name);
        // You can perform your tasks here.
    }


    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(Timer2)
        {
            Timer2 = false;
            StartTimer();
         
        }
      
        Finish_task2 = false;
   
 
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

        if (Task2_Mod1.allCubeClose && Finish_task2)
        {
            StopTimer();
            foreach (var interactable in interactables)
            {
                if (interactable.TryGetComponent<XRGrabInteractable>(out var grabInteractable))
                {
                    Destroy(grabInteractable);
                }
            }

        }


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
