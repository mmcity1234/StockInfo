using MvvmCross.Core.ViewModels;
using StockInfo.Uwp.Common;
using StockInfo.Uwp.Helper;
using StockInfo.Uwp.Models.Mops;
using StockInfo.Uwp.RestClient;
using StockInfo.Uwp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StockInfo.Uwp.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private List<StockInfoModel> _suggestionItemsSource = null;
        private string _searchStockText = null;

        public IStockQueryService StockService { get; set; }

        public INavigationService NavigationService { get; set; }

        #region Model Binding
        public DelegateCommand<AutoSuggestBoxQuerySubmittedEventArgs> AutoSuggestSearchCommand { get; }

        public DelegateCommand<AutoSuggestBoxTextChangedEventArgs> AutoSuggestTextChangeCommand { get; set; }

        public DelegateCommand<AutoSuggestBoxSuggestionChosenEventArgs> AutoSuggestChosenCommand { get; set; }
        public DelegateCommand<NavigationViewItemInvokedEventArgs> NativationItemInvokeCommand { get; set; }
        public DelegateCommand<NavigationViewBackRequestedEventArgs> NativationBackRequestedCommand { get; set; }
        public DelegateCommand<RoutedEventArgs> NativationLoadedCommand { get; set; }

        public string SearchStockText
        {
            get => _searchStockText;
            set
            {
                _searchStockText = value;
                RaisePropertyChanged(() => SearchStockText);
            }
        }

        public List<StockInfoModel> SuggestionItemsSource
        {
            get => _suggestionItemsSource;
            set
            {
                _suggestionItemsSource = value;
                RaisePropertyChanged(() => SuggestionItemsSource);
            }
        }

        #endregion

        public MainViewModel()
        {
            AutoSuggestSearchCommand = new DelegateCommand<AutoSuggestBoxQuerySubmittedEventArgs>(AutoSuggestSearchEvent);
            AutoSuggestTextChangeCommand = new DelegateCommand<AutoSuggestBoxTextChangedEventArgs>(AutoSuggestTextChangeEvent);
            AutoSuggestChosenCommand = new DelegateCommand<AutoSuggestBoxSuggestionChosenEventArgs>(AutoSuggestChosenEvent);
            NativationItemInvokeCommand = new DelegateCommand<NavigationViewItemInvokedEventArgs>(NavigationItemInvokeEvent);
            NativationBackRequestedCommand = new DelegateCommand<NavigationViewBackRequestedEventArgs>(NavigationBackRequestedEvent);
            NativationLoadedCommand = new DelegateCommand<RoutedEventArgs>(NavigationLoadedEvent);
        }

        #region AutoSuggest Event
        private void AutoSuggestChosenEvent(AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var stockModel = args.SelectedItem as StockInfoModel;
            if (stockModel != null)
            {
                SearchStockText = stockModel.Code;
            }
        }

        private void AutoSuggestSearchEvent(AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            var stockModel = args.ChosenSuggestion as StockInfoModel;
            if (stockModel != null)
            {
                // User selected an item from the suggestion list, take an action on it here.
            }
            else
            {
                //args.QueryText;
                // Use args.QueryText to determine what to do.
            }
        }

        private async void AutoSuggestTextChangeEvent(AutoSuggestBoxTextChangedEventArgs args)
        {
            MopsRestApi api = new MopsRestApi();

            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                List<StockInfoModel> stockList = await StockService.GetStockQueryList(SearchStockText);
                SuggestionItemsSource = stockList;
                //Set the ItemsSource to be your filtered dataset
                //sender.ItemsSource = dataset;
            }
        }
        #endregion

        private void NavigationItemInvokeEvent(NavigationViewItemInvokedEventArgs args)
        {

        }
        private void NavigationBackRequestedEvent(NavigationViewBackRequestedEventArgs args)
        {

        }
        private void NavigationLoadedEvent(RoutedEventArgs args)
        {

        }

    }
}
