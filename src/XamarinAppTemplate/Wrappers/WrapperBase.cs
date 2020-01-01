using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XamarinAppTemplate.Wrappers
{
    public class WrapperBase<TModel> : INotifyPropertyChanged
    {
        public TModel Model { get; protected set; }

        public WrapperBase(TModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            Model = model;
        }

        protected void SetValue<TValue>(TValue value, [CallerMemberName]string properyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(properyName);
            var currentValue = propertyInfo.GetValue(Model);

            if (!Equals(currentValue, value))
            {
                propertyInfo.SetValue(Model, value);

                OnPropertyChanged(properyName);
            }
        }

        protected TValue GetValue<TValue>([CallerMemberName]string properyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(properyName);

            return (TValue)propertyInfo?.GetValue(Model);

        }

        protected void NotifyAllPropertyChanged()
        {
            var type = this.GetType();

            var properties = type.GetProperties();

            foreach (var item in properties)
            {
                OnPropertyChanged(item.Name);
            }
        }


        public virtual void NotifyPropertesChanges()
        {
            var type = this.GetType();

            var properties = type.GetProperties();

            foreach (var item in properties)
            {
                OnPropertyChanged(item.Name);
            }

        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
