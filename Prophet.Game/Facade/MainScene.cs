using System;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.Game.Facade
{
    public static class MainScene
    {
        private static Scene _current;
        public static Scene Current = _current ?? (_current = Generate());



        private static Scene Generate()
        {
            var floor = new Decoration {Appearance = new ColoredCharacter('_', ConsoleColor.DarkGray), Name = "Пол"};
            
            var scene = new Scene();
            scene.InitializeLandscape(new Vector3(50, 10, 1));
            
            for (var x = 0; x < scene.Decorations.GetLength(0); x++)
            for (var y = 0; y < scene.Decorations.GetLength(1); y++)
            {
                scene.Decorations[x, y, 0] = floor;
            }

            scene.AddCharacter(Player.Current);

            return scene;
        }
    }
}