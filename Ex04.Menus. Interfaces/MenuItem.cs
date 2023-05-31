using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04.Menus.Interfaces
{
    public interface IMenuItemNotifier
    {
        void ActivateItem();
    }


    public class MenuItem : IMenuItemNotifier
    {
        public string m_Title; 
        public List<MenuItem> m_SubItems; 
        public IMenuItemNotifier m_Notifier; 

        //propetties
        public string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
            }
                
        }

        public List<MenuItem> SubItems
        {
            get
            {
                return m_SubItems;
            }
            set
            {
                m_SubItems = value;
            }
        }

        public IMenuItemNotifier Notifier
        {
            get
            {
                return m_Notifier;
            }
            set
            {
                m_Notifier = value;
            }
        }

        public MenuItem(string i_Title)
        {
            m_Title = i_Title;
            m_SubItems = new List<MenuItem>();
        }

        public MenuItem(string i_Title, IMenuItemNotifier i_Notifier)
        {
            m_Title = i_Title;
            m_SubItems = new List<MenuItem>();
            m_Notifier = i_Notifier;
        }

        public void ActivateItem()
        {
            m_Notifier.ActivateItem();
        }
    }

    // Notifier implementations for the action items
    public class TimeShowNotifier : IMenuItemNotifier
    {
        public void ActivateItem()
        {
            Console.WriteLine($"The Hour is: {DateTime.Now.ToString("HH:mm:ss")}");
        }
    }

    public class DateShowNotifier : IMenuItemNotifier
    {
        public void ActivateItem()
        {
            Console.WriteLine($"The Date is: {DateTime.Today.ToString("yyyy-MM-dd")}");
        }
    }

    public class ShowVersionNotifier : IMenuItemNotifier
    {
        public void ActivateItem()
        {
            Console.WriteLine("Version: 23.2.4.9805");
        }
    }

    public class CountSpacesNotifier : IMenuItemNotifier
    {
        public void ActivateItem()
        {
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine();
            int spaceCount = sentence.Count(c => c == ' ');
            Console.WriteLine($"Number of spaces in the sentence: {spaceCount}");
        }
    }
}
