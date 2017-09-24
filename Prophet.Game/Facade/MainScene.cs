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

            scene.AddCharacter(Player.Current);

            return scene;
        }
    }
}