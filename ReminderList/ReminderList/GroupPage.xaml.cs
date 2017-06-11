using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroupPage : ContentPage
    {
        public GroupPage()
        {
            InitializeComponent();
        }

        public void SaveGroup(object sender, EventArgs e)
        {
            var group = (MerchGroup)BindingContext;
            if (!String.IsNullOrEmpty(group.GroupName))
                App.Repository.SaveGroup(group);
            this.Navigation.PopAsync();
        }

        public void DeleteGroup(object sender, EventArgs e)
        {
            var group = (MerchGroup)BindingContext;
            App.Repository.DeleteGroup(group);
            this.Navigation.PopAsync();
        }

        public void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}