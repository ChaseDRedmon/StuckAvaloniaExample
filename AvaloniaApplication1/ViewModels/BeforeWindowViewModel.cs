using AvaloniaApplication1.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaApplication1.ViewModels;

public sealed partial class BeforeWindowViewModel : ObservableObject
{
    [RelayCommand]
    private void CloseWindow()
    {
        StrongReferenceMessenger.Default.Send<CloseWindowMessage>();
    }
}