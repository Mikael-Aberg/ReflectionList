using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionList
{
    class Menu
    {
        private string[,] menu;
        private int selected;
        private int maxSelection;

        public Menu()
        {
            Init();
            DrawMenu();
        }

        internal void HandleKeyEvent(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (selected > 0)
                    {
                        selected--;
                        DrawMenu();
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (selected < maxSelection)
                    {
                        selected++;
                        DrawMenu();
                    }
                    break;
                case ConsoleKey.Enter:
                    Type thisType = GetType();
                    MethodInfo theMethod = thisType.GetMethod(menu[selected, 1], BindingFlags.NonPublic | BindingFlags.Instance);
                    theMethod.Invoke(this, null);
                    break;
                default:
                    break;
            }
        }

        private void Init()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            selected = 0;
            menu = new string[,] { { "Option 1", "MenuOption1" }, { "Option 2", "MenuOption2" } };
            maxSelection = menu.GetLength(0) - 1;
        }

        public void DrawMenu()
        {
            Console.Clear();
            for (int i = 0; i < menu.GetLength(0); i++)
            {
                if (i == selected) Console.ForegroundColor = ConsoleColor.Yellow;
                else Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(menu[i, 0]);
            }
        }

        private void MenuOption1()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Menu option 1");
        }

        private void MenuOption2()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Menu option 2");
        }
    }
}
