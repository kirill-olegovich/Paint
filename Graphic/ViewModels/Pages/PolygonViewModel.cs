using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Paint.Models;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace Paint.ViewModels.Pages
{
    public class PolygonViewModel : ViewModelBase
    {
        private ObservableCollection<Shape> colection;
        private ObservableCollection<Names> nam_colection;
        private string name, points;
        private int thic = 1, select1 = 0, select2 = 0;
        public PolygonViewModel(ref ObservableCollection<Shape> col, ref ObservableCollection<Names> nam)
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

        public int Select1
        {
            get => select1;
            set
            {
                this.RaiseAndSetIfChanged(ref select1, value);
            }
        }

        public int Select2
        {
            get => select2;
            set
            {
                this.RaiseAndSetIfChanged(ref select2, value);
            }
        }

        // function
        public void Button_add()
        {
            if (Points != null && Name != null)
            {
                Avalonia.Point point;
                SolidColorBrush color1, color2;
                string temp_all_point = Points, temp_point = string.Empty;
                ObservableCollection<Avalonia.Point> col_point = new ObservableCollection<Point>();
                string color11 = string.Empty, color22 = string.Empty;
                if (select1 == 0)
                {
                    color1 = SolidColorBrush.Parse("Black");
                    color11 = "Black";
                }
                else if (select1 == 1)
                {
                    color1 = SolidColorBrush.Parse("Green");
                    color11 = "Green";
                }
                else if (select1 == 2)
                {
                    color1 = SolidColorBrush.Parse("Yellow");
                    color11 = "Yellow";
                }
                else if (select1 == 3)
                {
                    color1 = SolidColorBrush.Parse("Blue");
                    color11 = "Blue";
                }
                else if (select1 == 4)
                {
                    color1 = SolidColorBrush.Parse("Red");
                    color11 = "Red";
                }
                else
                {
                    color1 = SolidColorBrush.Parse("RosyBrown");
                    color11 = "RosyBrown";
                }

                if (select2 == 0)
                {
                    color2 = SolidColorBrush.Parse("Black");
                    color22 = "Black";
                }
                else if (select2 == 1)
                {
                    color2 = SolidColorBrush.Parse("Green");
                    color22 = "Green";
                }
                else if (select2 == 2)
                {
                    color2 = SolidColorBrush.Parse("Yellow");
                    color22 = "Yellow";
                }
                else if (select2 == 3)
                {
                    color2 = SolidColorBrush.Parse("Blue");
                    color22 = "Blue";
                }
                else if (select2 == 4)
                {
                    color2 = SolidColorBrush.Parse("Red");
                    color22 = "Red";
                }
                else
                {
                    color2 = SolidColorBrush.Parse("RosyBrown");
                    color22 = "RosyBrown";
                }

                Avalonia.Controls.Shapes.Polygon polygon = new Avalonia.Controls.Shapes.Polygon();
                for (int i = 0; i < temp_all_point.Length; i++)
                {
                    if (temp_all_point[i] != ' ') temp_point += temp_all_point[i];
                    else
                    {
                        point = Point.Parse(temp_point);
                        col_point.Add(point);
                        temp_point = string.Empty;
                    }
                    if (temp_all_point[i] != ' ' && i == temp_all_point.Length - 1)
                    {
                        point = Point.Parse(temp_point);
                        col_point.Add(point);
                        temp_point = string.Empty;
                    }
                }
                polygon.Name = Name;
                polygon.Stroke = color1;
                polygon.Fill = color2;
                polygon.Points = col_point;
                polygon.StrokeThickness = Thic;
                colection.Add(polygon);

                Names nam = new Names(polygon.Name, "polygon", color11, color22, temp_all_point, polygon.StrokeThickness);
                nam_colection.Add(nam);
            }
        }

        public void Button_cancel()
        {
            Name = string.Empty;
            Points = string.Empty;
            Select1 = 0;
            Select2 = 0;
            Thic = 1;
        }
    }
}
