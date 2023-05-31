using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        public string m_Title;
        public List<MenuItem> m_SubItems;
        public event Action m_MenuItemClicked;

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

        public MenuItem(string i_Title)
        {
            m_Title = i_Title;
            m_SubItems = new List<MenuItem>();
        }


        public void OnMenuItemClick()
        {
            m_MenuItemClicked.Invoke();
        }
    }
}
