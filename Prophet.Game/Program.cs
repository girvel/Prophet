using System;
using System.Collections.Generic;
using Prophet.ConsoleVisualizer;
using Prophet.Core;

namespace Prophet.Game
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var player = new Character {Appearance = new ColoredCharacter('@', ConsoleColor.White), Name = "Игрок"};
            var floor = new Decoration {Appearance = new ColoredCharacter('_', ConsoleColor.DarkGray), Name = "Пол"};
            var filler = new ColoredCharacter(' ', ConsoleColor.Black);
            
            var scene = new Scene
            {
                Decorations = new[,,]
                {
                    {{floor}, {floor}, {floor}, {floor}, {floor}, {floor}},
                    {{floor}, {floor}, {floor}, {floor}, {floor}, {floor}},
                    {{floor}, {floor}, {floor}, {floor}, {floor}, {floor}},
                    {{floor}, {floor}, {floor}, {floor}, {floor}, {floor}},
                    {{floor}, {floor}, {floor}, {floor}, {floor}, {floor}},
                    {{floor}, {floor}, {floor}, {floor}, {floor}, {floor}},
                },
                Characters = new[,,]
                {
                    {{null}, {null}, {null}, {null}, {null}, {null}},
                    {{null}, {null}, {null}, {player}, {null}, {null}},
                    {{null}, {null}, {null}, {null}, {null}, {null}},
                    {{null}, {null}, {null}, {null}, {null}, {null}},
                    {{null}, {null}, {null}, {null}, {null}, {null}},
                    {{null}, {null}, {null}, {null}, {null}, {null}},
                },
            };

            var view = new View {Position = new Vector(0, 0), Size = new Vector(50, 10)};
            new ConsoleViewer().Display(view.GetCurrentView(scene, filler));
            Console.ReadKey();
        }
    }
}