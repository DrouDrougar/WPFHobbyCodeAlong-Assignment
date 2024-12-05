using WPFHobbyCodeAlong.Models;

namespace WPFHobbyCodeAlong.ViewModels
{
    public class HobbiesItemViewModel : ViewModelBase
    {
        private readonly Hobbies _hobbies;

        public HobbiesItemViewModel(Hobbies hobbies)
        {
            this._hobbies = hobbies;
        }

        public string Name
        {
            get { return _hobbies.Name; }
            set
            {
                _hobbies.Name = value;
                RaisePropertyChanged();
            }

        }
        public string Description
        {
            get { return _hobbies.Description; }
            set
            {
                _hobbies.Description = value;
                RaisePropertyChanged();
            }
        }
        public bool IsActive
        {
            get { return _hobbies.IsActive; }
            set
            {
                _hobbies.IsActive = value;
                RaisePropertyChanged();
            }
        }

    }
}
