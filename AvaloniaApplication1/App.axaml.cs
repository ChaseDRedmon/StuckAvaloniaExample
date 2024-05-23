using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.ViewModels;
using AvaloniaApplication1.Views;

namespace AvaloniaApplication1;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override async void OnFrameworkInitializationCompleted()
    {
        // Force close after 10 minutes of inactivity
        using var cancellationToken = new CancellationTokenSource(TimeSpan.FromMinutes(10));
        
        var beforeWindow = new BeforeWindow(new BeforeWindowViewModel());
        beforeWindow.Show();

        while (!cancellationToken.IsCancellationRequested && beforeWindow.IsHidden is not true)
        {
            Console.WriteLine("Waiting for response...");
            await Task.Delay(TimeSpan.FromSeconds(5));
        }

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}