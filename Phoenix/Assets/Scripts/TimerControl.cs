using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class TimerControl: MonoBehaviour
    {
        private readonly Action<Character> _timerFinished;
        private readonly Character _character;
        private readonly System.Timers.Timer _timer;

        public TimerControl(float seconds, Action<Character> timerFinished, Character character)
        {
            _timerFinished = timerFinished;
            _character = character;
            _timer = new System.Timers.Timer(seconds*1000);
            _timer.Elapsed += TimerFinished; 
            _timer.Start();
        }


        private void TimerFinished(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timerFinished(_character);
            _timer.Stop();
        }
    }
}
