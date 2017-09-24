using System;
using System.Collections.Generic;
using Prophet.ConsoleVisualizer;
using Prophet.Core;
using Prophet.Core.Vector;
using Prophet.Game.Facade;

namespace Prophet.Game
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var viewer = new ConsoleViewer();
            viewer.Display(Ui.Current.GetCurrentView());

            while (true)
            {
                MainScene.Current.Step();
                Console.Clear();
                viewer.Display(Ui.Current.GetCurrentView());
            }
        }
    }
}