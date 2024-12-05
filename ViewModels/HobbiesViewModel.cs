using System.Collections.ObjectModel;
using WPFHobbyCodeAlong.Command;
using WPFHobbyCodeAlong.Models;

namespace WPFHobbyCodeAlong.ViewModels
{
    public class HobbiesViewModel : ViewModelBase
    {
        private ObservableCollection<HobbiesItemViewModel> hobbies = new();

        public ObservableCollection<HobbiesItemViewModel> Hobbies
        {
            get { return hobbies; }
            set
            {
                hobbies = value;
                RaisePropertyChanged();
            }
        }

        private HobbiesItemViewModel selectedHobbie;

        public HobbiesItemViewModel SelectedHobbie
        {
            get { return selectedHobbie; }
            set
            {
                selectedHobbie = value;
                RaisePropertyChanged();
                RemoveCommand.RaiseCanExicuteChanged();
            }
        }

        public DeligateCommand AddCommand { get; }
        public DeligateCommand RemoveCommand { get; }

        public HobbiesViewModel()
        {
            hobbies.Add(new HobbiesItemViewModel(new Hobbies() { Name = "Traveling", Description = "To take ones money and spend it all by going around places meeting new people and seeing things that you have never seen before.", IsActive = true }));
            hobbies.Add(new HobbiesItemViewModel(new Hobbies() { Name = "Video Games", Description = "The act of taking all ones money and spending it on games that you will never play, and spend thousands of hours on a few select games. It may be enjoyed with friends.", IsActive = true }));
            hobbies.Add(new HobbiesItemViewModel(new Hobbies() { Name = "3d Printing", Description = "This hobbie costs a lot of money, and can be used to create actual 3d objects that can be usefull or simply decorative.", IsActive = false }));

            AddCommand = new DeligateCommand(AddHobby);
            RemoveCommand = new DeligateCommand(RemoveHobby, CanRemove);
        }

        public async Task LoadAsync()
        {
            if (Hobbies.Any())
            {
                return;
            }
        }

        private void AddHobby(object? parameter)
        {
            Hobbies hobby = new Hobbies() { Name = "New", Description = "", IsActive = false };
            var hobbiesVm = new HobbiesItemViewModel(hobby);
            Hobbies.Add(hobbiesVm);
            SelectedHobbie = hobbiesVm;
        }

        private bool? CanRemove(object? paramter) => SelectedHobbie is not null;
        public void RemoveHobby(object? parameter)
        {
            if (SelectedHobbie is not null)
            {
                Hobbies.Remove(SelectedHobbie);
            }
            SelectedHobbie = null;

        }
    }
}
