﻿using System;
using Prophet.ConsoleVisualizer;
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
                viewer.Display(Ui.Current.GetCurrentView());
            }
        }
    }
}