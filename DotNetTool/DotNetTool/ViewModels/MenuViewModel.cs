using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTool.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }

        public MenuViewModel()
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>()
        {
            new() { MenuHeader = "工作台", Key = MenuKeys.MenuKeyDashboard,MenuIconName="Dashboard" },
            new() { MenuHeader = "时间转换",Key = MenuKeys.MenuKeyTimestamp,MenuIconName="Timestamp" },
            new() { MenuHeader = "格式化",Key = MenuKeys.MenuKeyFormat,MenuIconName="Format" },
            new() { MenuHeader = "系统设置", Key = MenuKeys.MenuKeySetting , MenuIconName = "Setting"},
        };
        }
    }

    public static class MenuKeys
    {
        /// <summary>
        /// 设置
        /// </summary>
        public const string MenuKeySetting = "Setting";

        /// <summary>
        /// 时间戳转换
        /// </summary>
        public const string MenuKeyTimestamp = "Timestamp";
        /// <summary>
        /// 工作台
        /// </summary>
        public const string MenuKeyDashboard = "Dashboard";
        /// <summary>
        /// 格式化
        /// </summary>
        public const string MenuKeyFormat = "Dashboard";
    }
}
