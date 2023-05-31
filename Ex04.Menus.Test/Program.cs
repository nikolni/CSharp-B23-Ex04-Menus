using System;
using System.Linq;
using Ex04.Menus.Interfaces;
using Ex04.Menus.Delegates;


namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            BuildAndDisplayTheFirstMenuWithInterfaces();
            BuildAndDisplayTheSecondMenuWithDelegates();
        }

        public static void BuildAndDisplayTheFirstMenuWithInterfaces()
        {
            Interfaces.MainMenu mainMenuForInterfaces = new Interfaces.MainMenu();

            Interfaces.MenuItem dateTimeMenuItem = new Interfaces.MenuItem("Show Date/Time");   //first level
            Interfaces.MenuItem showDateMenuItem = new Interfaces.MenuItem("Show Date", new DateShowNotifier());  //second level
            Interfaces.MenuItem showTimeMenuItem = new Interfaces.MenuItem("Show Time", new TimeShowNotifier());  //second level
            dateTimeMenuItem.m_SubItems.Add(showDateMenuItem);
            dateTimeMenuItem.m_SubItems.Add(showTimeMenuItem);

            Interfaces.MenuItem versionSpacesMenuItem = new Interfaces.MenuItem("Version and Spaces");   //first level
            Interfaces.MenuItem showVersionMenuItem = new Interfaces.MenuItem("Show Version", new ShowVersionNotifier());  //second level
            Interfaces.MenuItem countSpacesMenuItem = new Interfaces.MenuItem("Count Spaces", new CountSpacesNotifier());  //second level
            versionSpacesMenuItem.m_SubItems.Add(showVersionMenuItem);
            versionSpacesMenuItem.m_SubItems.Add(countSpacesMenuItem);

            mainMenuForInterfaces.AddMenuItem(dateTimeMenuItem);
            mainMenuForInterfaces.AddMenuItem(versionSpacesMenuItem);

            mainMenuForInterfaces.Show();
        }

        public static void BuildAndDisplayTheSecondMenuWithDelegates()
        {
            Delegates.MainMenu mainMenuForDelegates = new Delegates.MainMenu();

            Delegates.MenuItem dateTimeMenuItem = new Delegates.MenuItem("Show Date/Time");   //first level
            Delegates.MenuItem showDateMenuItem = new Delegates.MenuItem("Show Date");  //second level
            Delegates.MenuItem showTimeMenuItem = new Delegates.MenuItem("Show Time");  //second level
            dateTimeMenuItem.m_SubItems.Add(showDateMenuItem);
            dateTimeMenuItem.m_SubItems.Add(showTimeMenuItem);
            showDateMenuItem.m_MenuItemClicked += DateShow;
            showTimeMenuItem.m_MenuItemClicked += TimeShow;

            Delegates.MenuItem versionSpacesMenuItem = new Delegates.MenuItem("Version and Spaces");   //first level
            Delegates.MenuItem showVersionMenuItem = new Delegates.MenuItem("Show Version");  //second level
            Delegates.MenuItem countSpacesMenuItem = new Delegates.MenuItem("Count Spaces");  //second level
            versionSpacesMenuItem.m_SubItems.Add(showVersionMenuItem);
            versionSpacesMenuItem.m_SubItems.Add(countSpacesMenuItem);
            showVersionMenuItem.m_MenuItemClicked += ShowVersion;
            countSpacesMenuItem.m_MenuItemClicked += CountSpaces;

            mainMenuForDelegates.AddMenuItem(dateTimeMenuItem);
            mainMenuForDelegates.AddMenuItem(versionSpacesMenuItem);

            mainMenuForDelegates.Show();
        }

        private static void DateShowMenuItem_m_MenuItemClicked(Delegates.MenuItem obj)
        {
            throw new NotImplementedException();
        }

        public static void TimeShow()
        {
            Console.WriteLine($"The Hour is: {DateTime.Now.ToString("HH:mm:ss")}");
        }

        public static void DateShow()
        {
            Console.WriteLine($"The Date is: {DateTime.Today.ToString("yyyy-MM-dd")}");
        }


        public static void ShowVersion()
        {
            Console.WriteLine("Version: 23.2.4.9805");
        }

        public static void CountSpaces()
        {
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine();
            int spaceCount = sentence.Count(c => c == ' ');
            Console.WriteLine($"Number of spaces in the sentence: {spaceCount}");
        }
    }
}
