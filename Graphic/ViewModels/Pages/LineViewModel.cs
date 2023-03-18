using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Paint.Models;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace Paint.ViewModels.Pages
{
    public class LineViewModel : ViewModelBase
    {
        private ObservableCollection<Shape> colection;
        private ObservableCollection<Names> nam_colection;
        private string name, start_point, end_point;
        private int thick = 1, select;

        // constr
        public LineViewModel(ref ObservableCollection<Shape> col, ref ObservableCollection<Names> nam)
        {
            colection = col;
            nam_colection = nam;
            name = string.Empty;
            start_point = string.Empty;
            end_point = string.Empty;
        }

        // interf
        public string Name
        {
            get => name;
            set
            {
                this.RaiseAndSetIfChanged(ref name, value);
            }
        }
        public string Start
        {
            get => start_point;
            set
            {
                this.RaiseAndSetIfChanged(ref start_point, value);
            }
        }

        public string End
        {
            get => end_point;
            set
            {
                this.RaiseAndSetIfChanged(ref end_point, value);
            }
        }
        public int Thic
        {
            get => thick;
            set
            {
                this.RaiseAndSetIfChanged(ref thick, value);
            }
        }
        public int Select
        {
            get => select;
            set
            {
                this.RaiseAndSetIfChanged(ref select, value);
            }
        }

        // function
        public void Button_add()
        {
            if (Start != null && End != null && Name != null)
            {
                var point_start = Avalonia.Point.Parse(Start);
                var point_end = Avalonia.Point.Parse(End);

                SolidColorBrush color1;
                string color11 = string.Empty;
                if (select == 0)
                {
                    color1 = SolidColorBrush.Parse("Black");
                    color11 = "Black";
                }
                else if (select == 1)
                {
                    color1 = SolidColorBrush.Parse("Green");
                    color11 = "Green";
                }
                else if (select == 2)
                {
                    color1 = SolidColorBrush.Parse("Yellow");
                    color11 = "Yellow";
                }
                else if (select == 3)
                {
                    color1 = SolidColorBrush.Parse("Blue");
                    color11 = "Blue";
                }
                else if (select == 4)
                {
                    color1 = SolidColorBrush.Parse("Red");
                    color11 = "Red";
                }
                else
                {
                    color1 = SolidColorBrush.Parse("RosyBrown");
                    color11 = "RosyBrown";
                }



                Avalonia.Controls.Shapes.Line line = new Line();
                line.Name = Name;
                line.StartPoint = point_start;
                line.EndPoint = point_end;
                line.Stroke = color1;
                line.StrokeThickness = Thic;
                colection.Add(line);

                Names nam = new Names(line.Name, "line", Start, End, line.StrokeThickness, color11);
                nam_colection.Add(nam);
            }
        }

        public void Button_cancel()
        {
            Name = string.Empty;
            Start = string.Empty;
            End = string.Empty;
            Thic = 1;
            Select = 0;
        }
    }
}
