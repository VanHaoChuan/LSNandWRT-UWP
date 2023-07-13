using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.ApplicationModel.Core;
using Windows.Data.Xml.Dom;
using Windows.Globalization;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.System;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace LSNandWRT_UWPVer
{
    public sealed partial class MainPage : Page
    {


        Windows.Storage.StorageFile storageFile;
        List<LaW.Word> words = new List<LaW.Word>();
        string wordFile = "";
        ObservableCollection<LaW.Word> wordCollection = new ObservableCollection<LaW.Word>();
        int currentWordIndex = 0;
        public bool switched = false;
        SizeChangeBiding sizeChangeBiding;
        TileUpdater tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication();
        public MainPage()
        {
            this.InitializeComponent();
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            ApplicationView.GetForCurrentView().TitleBar.ButtonBackgroundColor = Color.FromArgb(0, 0, 0, 0);
            initializeFrostedGlass(GlassHost);
            tileUpdater.Clear();
            sizeChangeBiding = new SizeChangeBiding();
            MainGrid.DataContext = sizeChangeBiding;
            tileUpdater.EnableNotificationQueue(true);

        }

        private void Switch(object sender, RoutedEventArgs e)
        {


            switched = !switched;
            if (switched)
            {
                SwitchBut.Content = "Trans";
            }
            if (!switched)
            {
                SwitchBut.Content = "Origin";
            }
        }
        private void Replay(object sender, RoutedEventArgs e)
        {
            if (wordCollection.Count != 0)
                LaW.Reader.Reader.Read(words[currentWordIndex], switched, MediaElement);
            AwnserBox.Focus(FocusState.Programmatic);
        }
        private void ShowCurrentWord(object sender, RoutedEventArgs e)
        {
            CurrentWord.Opacity = 1;

        }
        private void PreviousBut(object sender, RoutedEventArgs e)
        {
            if (currentWordIndex >= 1 && words.Count > 0)
            {
                currentWordIndex -= 1;
                WordList.SelectedIndex = currentWordIndex;

                LaW.Reader.Reader.Read(words[currentWordIndex], switched, MediaElement);
                CurrentWord.Text = words[currentWordIndex].WordText;
                CurrentWord.Opacity = 0;
                AdditionInfo.Text = words[currentWordIndex].AdditionalInformation;
                WordList.SelectedIndex = currentWordIndex;
                WordList.SelectedItem = WordList.Items[currentWordIndex];
                WordList.ScrollIntoView(WordList.SelectedItem);
                AwnserBorder.Background.Opacity = 0;
                AwnserBox.Focus(FocusState.Programmatic);
                AwnserBox.Text = "";
            }
        }
        private void NextBut(object sender, RoutedEventArgs e)
        {
            if (currentWordIndex <= words.Count - 2 && words.Count > 0)
            {
                Debug.WriteLine("Button");
                Debug.WriteLine(currentWordIndex);
                Debug.WriteLine(WordList.SelectedIndex);
                currentWordIndex += 1;
                WordList.SelectedIndex = currentWordIndex;
                LaW.Reader.Reader.Read(words[currentWordIndex], switched, MediaElement);
                CurrentWord.Opacity = 0;
                CurrentWord.Text = words[currentWordIndex].WordText;
                AdditionInfo.Text = words[currentWordIndex].AdditionalInformation;
                WordList.SelectedItem = WordList.Items[currentWordIndex];

                WordList.ScrollIntoView(WordList.SelectedItem);
                AwnserBox.Text = "";
                AwnserBorder.Background.Opacity = 0;
                AwnserBox.Focus(FocusState.Programmatic);
            }
        }
        private async void Choose(object sender, RoutedEventArgs e)
        {
            currentWordIndex = 0;
            wordCollection.Clear();
            AwnserBox.Text = "";
            FileLocationText.Text = "File Location";
            AdditionInfo.Text = "";
            var filePicker = new Windows.Storage.Pickers.FileOpenPicker();
            filePicker.ViewMode = PickerViewMode.List;
            filePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            filePicker.FileTypeFilter.Add(".txt");
            storageFile = await filePicker.PickSingleFileAsync();

            if (storageFile != null)
            {
                wordFile = storageFile.Name;
                FileLocationText.Text = wordFile;
                string wordString = await Windows.Storage.FileIO.ReadTextAsync(storageFile);
                LaW.Word.FillWordFromFile(ref words, wordString);
                LaW.Word.RandomSort(ref words);

                foreach (var word in words)
                {
                    wordCollection.Add(word);
                    UpdateTile(word.WordText, word.Translation);
                }

                WordList.DataContext = wordCollection;
                AdditionInfo.Text = words[currentWordIndex].AdditionalInformation;
                LaW.Reader.Reader.Read(words[currentWordIndex], switched, MediaElement);
                CurrentWord.Text = words[currentWordIndex].WordText;
                CurrentWord.Opacity = 0;
                AwnserBorder.Background.Opacity = 0;
                AwnserBox.Focus(FocusState.Programmatic);

            }
        }
       
        private void Search(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text != "")
            {
                int index = -1;
                foreach (var word in wordCollection)
                {

                    index++;
                    if (word.WordText.ToUpper() == SearchBox.Text.ToUpper() || word.Translation == SearchBox.Text.ToUpper())
                    {
                        if (wordCollection.Count >= 0)
                        {
                            currentWordIndex = index;
                            LaW.Reader.Reader.Read(words[currentWordIndex], switched, MediaElement);
                            CurrentWord.Text = words[currentWordIndex].WordText;
                            CurrentWord.Opacity = 0;
                            AdditionInfo.Text = words[currentWordIndex].AdditionalInformation;
                            WordList.SelectedItem = WordList.Items[index];
                            WordList.ScrollIntoView(WordList.SelectedItem);
                            AwnserBox.Focus(FocusState.Programmatic);
                        }
                    }
                }
            }
        }
        private void CheckAwnser(object sender, TextChangedEventArgs e)
        {
            if (AwnserBox.Text.ToLower() == words[currentWordIndex].WordText.ToLower())
            {
                AwnserBorder.Background = new SolidColorBrush(Windows.UI.Colors.Beige);
                LaW.Reader.Reader.Beep(MediaElement);
            }
            else
                AwnserBorder.Background = new SolidColorBrush(Windows.UI.Colors.MediumVioletRed);
            AwnserBorder.Background.Opacity = 0.9;
        }
        private void ReadAdditionalInfo(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)

        {
            if (words.Count > 0)
                LaW.Reader.Reader.Read(words[currentWordIndex], MediaElement);
        }

        private void Select(object sender, ItemClickEventArgs e)
        {
            if (wordCollection.Count >= 1)
            {
                currentWordIndex = (int)(WordList?.Items?.IndexOf(e.ClickedItem));
                WordList.SelectedIndex = currentWordIndex;
                CurrentWord.Text = words[WordList.SelectedIndex].WordText;
                WordList.SelectedItem = WordList.Items[WordList.SelectedIndex];
                CurrentWord.Opacity = 0;
                AdditionInfo.Text = words[WordList.SelectedIndex].AdditionalInformation;
                WordList.ScrollIntoView(WordList.SelectedItem);
                ApplicationLanguages.PrimaryLanguageOverride = Windows.Globalization.Language.CurrentInputMethodLanguageTag;
                AwnserBorder.Background.Opacity = 0;
                LaW.Reader.Reader.Read(words[WordList.SelectedIndex], switched, MediaElement);
                AwnserBorder.Background.Opacity = 0;
                AwnserBox.Focus(FocusState.Programmatic);
                AwnserBox.Text = "";
                Debug.WriteLine("After");
                Debug.WriteLine(currentWordIndex);
                Debug.WriteLine(WordList.SelectedIndex);

            }
        }
        void UpdateTile(string _contentMain, string _contentTrans)
        {
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileSmall = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText() {HintStyle = AdaptiveTextStyle.Title, Text = _contentMain },
                                new AdaptiveText() {HintStyle = AdaptiveTextStyle.Subtitle, Text = _contentTrans }
                            }
                        }
                    },

                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new AdaptiveText() {HintStyle = AdaptiveTextStyle.Title, Text = _contentMain },
                    new AdaptiveText() {HintStyle = AdaptiveTextStyle.Subtitle, Text = _contentTrans }
                }
                        }
                    },

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new AdaptiveText() { HintStyle = AdaptiveTextStyle.Title,Text = _contentMain },
                    new AdaptiveText() {HintStyle = AdaptiveTextStyle.Subtitle, Text = _contentTrans }
                }
                        }
                    },

                    TileLarge = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new AdaptiveText() {HintStyle = AdaptiveTextStyle.Title, Text = _contentMain },
                    new AdaptiveText() {HintStyle = AdaptiveTextStyle.Subtitle, Text = _contentTrans }
                }
                        }
                    }
                }
            };

            XmlDocument xml = content.GetXml();
            TileNotification tileNotification = new TileNotification(xml);
            TileUpdater tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication();
            tileUpdater.Update(tileNotification);
        }
        void KeyDownEventProc(CoreWindow sender, KeyEventArgs e)
        {
            if (e.VirtualKey == VirtualKey.PageUp)
            {
                PreviousBut(sender, null);
                return;
            }
            if (e.VirtualKey == VirtualKey.PageDown)
            {
                NextBut(sender, null);
                return;
            }
            if (e.VirtualKey == VirtualKey.Home)
            {
                Replay(sender, null);
                return;
            }
            if (e.VirtualKey == VirtualKey.End)
            {
                ShowCurrentWord(sender, null);
                return;
            }
            if (e.VirtualKey == VirtualKey.Enter)
            {
                Search(sender, null);
                return;
            }
            if (IsCtrlKeyPressed() && e.VirtualKey == VirtualKey.F)
            {
                Choose(sender, null);
                return;
            }
            if (IsCtrlKeyPressed() && e.VirtualKey == VirtualKey.W)
            {
                Application.Current.Exit();
                return;
            }
        }
        
        public bool IsCtrlKeyPressed()
        {
            var ctrlState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Control);
            return (ctrlState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
        }
        private void initializeFrostedGlass(UIElement glassHost)
        {
            Visual hostVisual = ElementCompositionPreview.GetElementVisual(glassHost);
            Compositor compositor = hostVisual.Compositor;
            var backdropBrush = compositor.CreateHostBackdropBrush();
            var glassVisual = compositor.CreateSpriteVisual();
            glassVisual.Brush = backdropBrush;
            ElementCompositionPreview.SetElementChildVisual(glassHost, glassVisual);
            var bindSizeAnimation = compositor.CreateExpressionAnimation("hostVisual.Size");
            bindSizeAnimation.SetReferenceParameter("hostVisual", hostVisual);
            glassVisual.StartAnimation("Size", bindSizeAnimation);
        }


        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            sizeChangeBiding.PlayButWidth = grid.ActualWidth / 4;
            sizeChangeBiding.PlayButHeight = grid.ActualHeight;
            sizeChangeBiding.SearchandFileButHeight = SearchBox.ActualHeight;
            sizeChangeBiding.SearchandFileButWidth = SearchBox.ActualWidth / 3;
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {

            Window.Current.CoreWindow.KeyDown += KeyDownEventProc;
            var file = e.Parameter as StorageFile;
            if (file != null)
            {
                using (var stream = await file.OpenAsync(FileAccessMode.Read))
                {
                    wordFile = file.Name;
                    FileLocationText.Text = wordFile;
                    string wordString = await Windows.Storage.FileIO.ReadTextAsync(file);
                    LaW.Word.FillWordFromFile(ref words, wordString);
                    foreach (var word in words)
                    {
                        wordCollection.Add(word);
                        UpdateTile(word.WordText, word.Translation);
                    }
                    WordList.DataContext = wordCollection;
                    AdditionInfo.Text = words[currentWordIndex].AdditionalInformation;
                    LaW.Reader.Reader.Read(words[currentWordIndex], switched, MediaElement);
                    CurrentWord.Text = words[currentWordIndex].WordText;
                    CurrentWord.Opacity = 0;
                    Random random = new Random();
                    AwnserBorder.Background.Opacity = 0;
                }
            }
        }

    }
}
