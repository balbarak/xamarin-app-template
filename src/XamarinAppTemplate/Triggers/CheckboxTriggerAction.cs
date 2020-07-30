using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace XamarinAppTemplate
{
    public class CheckboxTriggerAction : TriggerAction<StackLayout>
    {
        protected override void Invoke(StackLayout sender)
        {
            if (sender == null)
                return;

            var checkBox = sender.Children.Where(a => a is CheckBox).FirstOrDefault() as CheckBox;

            if (checkBox == null)
                return;

            checkBox.IsChecked = !checkBox.IsChecked;

        }
    }
}
