using System;
using System.Collections.Generic;
using Prophet.ConsoleVisualizer;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.Game
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var player = new Character
            {
                Appearance = new ColoredCharacter('@', ConsoleColor.White), 
                Name = "Игрок",
                Behaviour = new PlayerBehaviour(),
            };
            
            var floor = new Decoration {Appearance = new ColoredCharacter('_', ConsoleColor.DarkGray), Name = "Пол"};
            var filler = new ColoredCharacter(' ', ConsoleColor.Black);
            
            var scene = new Scene();
            scene.InitializeLandscape(new Vector3(6, 6, 1));
            scene.Decorations = new[,,]
            {
                {{floor}, {floor}, {floor}, {floor}, {floor}, {floor}},
                {{floor}, {floor}, {floor}, {floor}, {floor}, {floor}},
                {{floor}, {floor}, {floor}, {floor}, {floor}, {floor}},
                {{floor}, {floor}, {floor}, {floor}, {floor}, {floor}},
                {{floor}, {floor}, {floor}, {floor}, {floor}, {floor}},
                {{floor}, {floor}, {floor}, {floor}, {floor}, {floor}},
            };

            scene.AddCharacter(player);

            var view = new View {Position = new Vector2(0, 0), Size = new Vector2(50, 10)};
            var viewer = new ConsoleViewer();
            viewer.Display(view.GetCurrentView(scene, filler));

            while (true)
            {
                scene.Step();
                Console.Clear();
                viewer.Display(view.GetCurrentView(scene, filler));
            }
        }
    }
}