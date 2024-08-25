using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace DotNetTool.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    public MenuViewModel Menus { get; set; } = new MenuViewModel();

    private object? _content;

    public object? Content
    {
        get => _content;
        set => SetProperty(ref _content, value);
    }

    public MainViewModel()
    {
        WeakReferenceMessenger.Default.Register<MainViewModel, string>(this, OnNavigation);
    }

    [RelayCommand]
    public void Initialize()
    { }


    private void OnNavigation(MainViewModel vm, string s)
    {

        Content = s switch
        {
            MenuKeys.MenuKeyTimestamp => new TimestampViewModel(),
            //MenuKeys.MenuKeyMember => ServiceLocator.ProviderInstance.GetService<MemberViewModel>(),
            //MenuKeys.MenuKeyOrder => new BadgeDemoViewModel(),
            //MenuKeys.MenuKeyMember => new BannerDemoViewModel(),
            //MenuKeys.MenuKeyAsset => new ButtonGroupDemoViewModel(),
            //MenuKeys.MenuKeyMarketing => new BreadcrumbDemoViewModel(),
            //MenuKeys.MenuKeySetting => new SettingViewModel(),
        };
    }
}
