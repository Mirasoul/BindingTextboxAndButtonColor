using System.Windows.Input;
using System.Windows.Media;

namespace BindingTextboxAndButtonColor
{
    public struct PersonFeatures
    {
        // public byte Age;
        // public byte Height;
        public string Name;
        public string Surname;
    }

    public class Person : ObservedObject
    {
        private string _numberOfClick = "0";

        private ICommand? _myButton = null;
        private PersonFeatures _name;
        private PersonFeatures _surname;
        
        private Brush _speedColor;

        private ToDoPerson _toDo = new ToDoPerson();
        private ToDoButton _toDoButton = new ToDoButton();

        public string OurGuyName
        {
            get
            {
                return _name.Name;
            }
        }
        public string OurGuySurname
        {
            get
            {
                return _surname.Surname;
            }
            set
            {
                _surname.Surname = value;
                OnPropertyChanged(nameof(OurGuySurname));
            }
        }
        public string OurGuyActions
        {
            get
            {
                return _numberOfClick.ToString();
            }
            set
            {
                _numberOfClick = value;
                OnPropertyChanged(nameof(OurGuyActions));
            }
        } 
        public ICommand MyButtonCommands
        {
            get
            {
                if (_myButton == null)
                {
                    _myButton = new RelayCommand(OurGuyClick);
                    OurGuyChangedColor = _toDoButton.MyColor;
                }
                return _myButton;
            }
        }
        public Brush OurGuyChangedColor
        {
            get
            {
                return _speedColor;
            }
            set
            {
                _speedColor = value;
                OnPropertyChanged(nameof(OurGuyChangedColor));
            }
        }
      
        public Person()
        {
            /*Inicjalizacja imienia i nazwiska*/
            _name.Name = "Arkadiusz";
            _surname.Surname = "B.";
        }
  
        public void OurGuyClick(object obj)
        {
            OurGuyActions = _toDo.PressMyButton();           
            OurGuyWouldLikeToChangeBackgroundColor();
         }
        public void OurGuyWouldLikeToChangeBackgroundColor()
        {
            _toDoButton.ChangeColorOfTheTextBox();
            OurGuyChangedColor = _toDoButton.MyColor;
        }
    }


}
