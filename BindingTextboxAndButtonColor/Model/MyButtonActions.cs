using System.Windows.Media;

namespace BindingTextboxAndButtonColor
{

    interface IToDoButtonable
    {
        string Action();
        void ChangeColorOfTheTextBox();
    }
 
    public class ToDoButton: IToDoButtonable
    {
        private Brush _myColorYellow = new SolidColorBrush(Colors.Yellow);
        private Brush _myColorGreen = new SolidColorBrush(Colors.Green);

        private static byte _numberOfClick = 0; // static - it has to avaiable in all methods
        private const byte _valueWhenSwitchColor = 5;
        public Brush MyColor
        {
            get;
            set;
        } = new SolidColorBrush(Colors.Azure);//default color of the textbox

        public string Action()
        {
            //ChangeColor();
            return string.Format("- he pressed the button {0} times ",_numberOfClick++);
        }
        public void ChangeColorOfTheTextBox()
        {
            if(_numberOfClick < _valueWhenSwitchColor) 
            {
                MyColor = _myColorYellow;
            }
            else
            {
                MyColor = _myColorGreen;
            }
        }
    }
}
