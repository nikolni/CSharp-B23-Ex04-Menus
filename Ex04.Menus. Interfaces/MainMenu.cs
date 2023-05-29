

namespace Ex04.Menus.Interfaces
{
    public interface SelectedItemListener
    {
        void ImplementAnItem(MenuItem i_MenuItem);
    }

    internal class MainMenu : SelectedItemListener
    {


        public void ImplementAnItem(MenuItem i_MenuItem)
        {
            i_MenuItem.ActivateItem();
        }
    }
}
