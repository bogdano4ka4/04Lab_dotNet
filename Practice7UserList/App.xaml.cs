using System.Windows;
using System.Windows.Threading;

namespace Practice7UserList
{
    public partial class App : Application
    {
        public App()
        {
             this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
            e.Handled = true;
        }
    }
}
