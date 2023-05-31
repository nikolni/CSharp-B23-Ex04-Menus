

using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public interface IMainMenuListener
    {
        void OnMenuItemSelected(MenuItem i_MenuItem);
    }

    public class MainMenu : IMainMenuListener
    {
        private List<MenuItem> m_MenuItems;

        public MainMenu()
        {
            m_MenuItems = new List<MenuItem>();
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            m_MenuItems.Add(i_MenuItem);
        }

        public void OnMenuItemSelected(MenuItem i_MenuItem)
        {
            if (i_MenuItem.SubItems.Count > 0)   //is a sub Memu
            {
                DisplaySubMenu(i_MenuItem);
            }
            else
            {
                Console.Clear();
                i_MenuItem.ActivateItem();
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        public void Show()
        {
            bool v_ChoiceIsZero = false;

            while (!v_ChoiceIsZero)
            {
                Console.Clear();
                PrintMainMenu();
                int choice = GetMenuChoice(m_MenuItems.Count);

                if (choice == 0)
                {
                    v_ChoiceIsZero = true;
                    break; // Exit
                }

                MenuItem selectedMenuItem = m_MenuItems[choice - 1];   
                OnMenuItemSelected(selectedMenuItem);
            }
        }

        private void PrintMainMenu()
        {
            Console.WriteLine("**Interfaces Main Menu**");
            Console.WriteLine("--------------------------");

            for (int i = 0; i < m_MenuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1} -> {m_MenuItems[i].Title}");
            }

            Console.WriteLine("0 -> Exit");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"\nEnter your request: (1 to {m_MenuItems.Count} or press '0' to Exit).");
        }

        private void DisplaySubMenu(MenuItem i_MenuItem)
        {
            bool v_ChoiceIsZero = false;

            while (!v_ChoiceIsZero)
            {
                Console.Clear();
                PrintSubMenuItems(i_MenuItem);  
                int choice = GetMenuChoice(i_MenuItem.SubItems.Count);

                if (choice == 0)
                {
                    v_ChoiceIsZero = true;
                    break; // Back to previous menu
                }

                MenuItem selectedMenuItem = i_MenuItem.SubItems[choice - 1];
                OnMenuItemSelected(selectedMenuItem);
            }
        }

        
        private void PrintSubMenuItems(MenuItem i_MenuItem)
        {
            Console.WriteLine($"**{i_MenuItem.Title}**");
            Console.WriteLine("--------------------------");

            for (int i = 0; i < i_MenuItem.m_SubItems.Count; i++)
            {
                Console.WriteLine($"{i + 1} -> {i_MenuItem.SubItems[i].Title}");
            }

            Console.WriteLine("0 -> Back");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"\nEnter your request: (1 to {i_MenuItem.SubItems.Count} or press '0' to Back).");
        }

        private int GetMenuChoice(int i_MaxChoice)
        {
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > i_MaxChoice)
            {
                Console.WriteLine("Invalid input. Please try again:");
            }

            return choice;
        }     
    }
}
