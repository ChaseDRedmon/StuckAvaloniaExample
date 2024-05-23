using Avalonia.Controls;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.ViewModels;
using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaApplication1;


public sealed partial class BeforeWindow :
    Window,
    IRecipient<CloseWindowMessage>
{
    private readonly BeforeWindowViewModel _viewModel;
    
    public bool? IsHidden { get; private set; }
    
    public BeforeWindow(BeforeWindowViewModel viewModel)
    {
        _viewModel = viewModel;
        DataContext = _viewModel;
        
        StrongReferenceMessenger.Default.Register<CloseWindowMessage>(this);
        
        InitializeComponent();
    }

    public void Receive(CloseWindowMessage message)
    {
        IsHidden = true;
        Hide();
    }
}