using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Paint.Models;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace Paint.ViewModels.Pages
{
    public class PolyLineViewModel : ViewModelBase
    {
        private ObservableCollection<Shape> colection;
        private ObservableCollection<Names> nam_colection;
        private string name, points;
        private int thic = 1, select = 0;
        public PolyLineViewModel(ref ObservableCollection<Shape> col, ref ObservableCollection<Names> nam)
        {
            colection = col;
            nam_colection = nam;
            name = string.Empty;
            points = string.Empty;
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

        public string Points
        {
            get => points;
            set
            {
                this.RaiseAndSetIfChanged(ref points, value);
            }
        }

        public int Thic
        {
            get => thic;
            set
            {
                this.RaiseAndSetIfChanged(ref thic, value);
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
            if (Points != null && Name != null)
            {
                string temp_point = string.Empty, temp_all_point = Points;
                int i = 0;
                Avalonia.Point point;
                SolidColorBrush color1;
                ObservableCollection<Avalonia.Point> col_point = new ObservableCollection<Avalonia.Point>();

                string color11 = string.Empty, color22 = string.Empty;
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


                Polyline polyline = new Polyline();
                polyline.Name = Name;
                for (i = 0; i < temp_all_point.Length; i++)
                {
                    if (temp_all_point[i] != ' ') temp_point += temp_all_point[i];
                    else
                    {
                        point = Avalonia.Point.Parse(temp_point);
                        col_point.Add(point);
                        temp_point = string.Empty;
                    }
                    if (temp_all_point[i] != ' ' && i == temp_all_point.Length - 1)
                    {
                        point = Avalonia.Point.Parse(temp_point);
                        col_point.Add(point);
                        temp_point = string.Empty;
                    }
                }
                polyline.Points = col_point;
                polyline.Stroke = color1;
                polyline.StrokeThickness = Thic;
                colection.Add(polyline);

                Names nam = new Names(polyline.Name, "polyline", temp_all_point, polyline.StrokeThickness, color11);
                nam_colection.Add(nam);
            }
        }

        public void Button_cancel()
        {
            Name = string.Empty;
            Points = string.Empty;
            Select = 0;
            Thic = 1;
        }
    }
}
