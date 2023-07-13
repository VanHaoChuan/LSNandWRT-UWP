using System.ComponentModel;

namespace LSNandWRT_UWPVer
{
    public class SizeChangeBiding : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string _propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName: _propertyName));
        }
        private double searchandFileButHeight = 0;
        private double searchandFileButWidth = 0;
        public double SearchandFileButHeight
        {
            get { return searchandFileButHeight; }
            set
            {
                searchandFileButHeight = value;
                NotifyPropertyChanged("SearchandFileButHeight");
            }
        }
        public double SearchandFileButWidth
        {
            get { return searchandFileButWidth; }
            set
            {
                searchandFileButWidth = value;
                NotifyPropertyChanged("SearchandFileButWidth");
            }
        }
        private double playButHeight = 0;
        private double playButWidth = 0;
        public double PlayButWidth
        {
            get { return playButWidth; }
            set
            {
                playButWidth = value;
                NotifyPropertyChanged("PlayButWidth");
            }
        }
        public double PlayButHeight
        {
            get { return playButHeight; }
            set
            {
                playButHeight = value;
                NotifyPropertyChanged("PlayButHeight");
            }
        }

    }
}
