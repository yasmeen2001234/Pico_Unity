using Tobii.XR.Examples;
using UnityEngine;
using UnityEngine.UI;
namespace Tobii.XR.Examples
{
    public class Mod2_Task1_timer : MonoBehaviour
    {
        private bool timerStarted = false;
        private bool Finish_task1 = false;
        private float startTime = 0f;
        private float elapsedTime = 0f;
        [SerializeField] Text timer1;


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

            if (Task1_mod2.allTorusClose && GazeGrab.Finishtask1 )
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
}