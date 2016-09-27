namespace Catel.WP80.Application1.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    using Catel.Data;
    using Catel.MVVM;
    using Catel.Services;

    using Models;

    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            Items = new ObservableCollection<ItemData>();
        }

        public override string Title { get { return "Catel.WP80.Application1"; } }

        /// <summary>
        /// Gets or sets the collection of items.
        /// </summary>
        public ObservableCollection<ItemData> Items
        {
            get { return GetValue<ObservableCollection<ItemData>>(ItemsProperty); }
            private set { SetValue(ItemsProperty, value); }
        }

        /// <summary>
        /// Register the Items property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ItemsProperty = RegisterProperty("Items", typeof(ObservableCollection<ItemData>));

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }

    public class DesignMainPageViewModel : MainPageViewModel
    {
        public DesignMainPageViewModel()
        {
            // Design data
            Items.Add(new ItemData("Design data 1"));
            Items.Add(new ItemData("Design data 2"));
            Items.Add(new ItemData("Design data 3"));
            Items.Add(new ItemData("Design data 4"));
            Items.Add(new ItemData("Design data 5"));
        }
    }
}