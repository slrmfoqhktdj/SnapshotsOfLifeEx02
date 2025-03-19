using System;
using System.Collections.Generic;

namespace SnapshotsOfLifeEx02
{
    public class ActionSource
    {
        List<ActionListener> listeners = new List<ActionListener>();

        public void AddActionListener(ref ActionListener listener)
        {
            listeners.Add(listener);
        }

        public void RemoveActionListener(ref ActionListener listener)
        {
            listeners.Remove(listener);
        }

        public void FireEvent(ActionEvent.Command command, IntPtr arg)
        {
            ActionEvent e = new ActionEvent(command, arg);

            for (var i = 0; i < listeners.Count; i++)
            {
                listeners[i].ActionPerformed(e);
            }
        }
    }
}
