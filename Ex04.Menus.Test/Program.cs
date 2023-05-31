using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            MainMenu mainMenuForInterfaces = new MainMenu();
            //MainMenu mainMenuForDelegates = new MainMenu();

            // Build the first menu for interface
            MenuItem dateTimeMenuItem = new MenuItem("Show Date/Time");   //first level
            MenuItem dateShowMenuItem = new MenuItem("Show Date", new DateShowNotifier());  //second level
            MenuItem timeShowMenuItem = new MenuItem("Show Time", new TimeShowNotifier());  //second level
            timeDateMenuItem.m_SubItems.Add(dateShowMenuItem);
            timeDateMenuItem.m_SubItems.Add(timeShowMenuItem);

            MenuItem versionSpacesMenuItem = new MenuItem("Version and Spaces");   //first level
            MenuItem showVersionMenuItem = new MenuItem("Show Version", new ShowVersionNotifier());  //second level
            MenuItem countSpacesMenuItem = new MenuItem("Count Spaces", new CountSpacesNotifier());  //second level
            versionSpacesMenuItem.m_SubItems.Add(showVersionMenuItem);
            versionSpacesMenuItem.m_SubItems.Add(countSpacesMenuItem);

            mainMenuForInterfaces.AddMenuItem(dateTimeMenuItem);
            mainMenuForInterfaces.AddMenuItem(versionSpacesMenuItem);

            // Display the first menu
            mainMenuForInterfaces.Show();


            // Build the first menu for delegates

            // Display the first menu
            //mainMenuForDelegates.Show();
        }
    }
}
