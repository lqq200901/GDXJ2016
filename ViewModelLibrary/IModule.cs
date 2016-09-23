using System.Windows.Controls;

namespace ViewModelLibrary
{
    public interface IModule
    {
        string Name { get; }
        UserControl UserInterface { get; }
        void Deactivate();
    }
}
