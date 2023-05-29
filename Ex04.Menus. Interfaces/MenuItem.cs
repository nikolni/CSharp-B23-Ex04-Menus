using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{

    public interface MenuItem
    {
        void ActivateItem();
        void NotifySelectedItemListener();
    }


    public class Submenu : MenuItem
    {
        SelectedItemListener selectedItemListener = new SelectedItemListener();


        LinkedList<MenuItem> m_ItemsList;

        public void NotifySelectedItemListener()
        {

        }

        public void ActivateItem()
        {
            PrintSubMenu();


        }
    }


    public class FinalItem : MenuItem
    {
        public void NotifySelectedItemListener()
        {

        }


        public void ActivateItem()
        {

        }
    }

}
