using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Paint.Models;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace Paint.ViewModels.Pages
{
    public class PathViewModel : ViewModelBase
    {
        private ObservableCollection<Shape> colection;
        private ObservableCollection<Names> nam_colection;
        private string name, points;
        private int thic = 1, select1 = 0, select2 = 0;
        public PathViewModel(ref ObservableCollection<Shape> col, ref ObservableCollection<Names> nam)
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
                string all_comand = Points;
                SolidColorBrush color1, color2;
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

                Avalonia.Controls.Shapes.Path path = new Avalonia.Controls.Shapes.Path();
                path.Name = Name;
                path.Stroke = color1;
                path.StrokeThickness = Thic;
                path.Fill = color2;
                path.Data = Avalonia.Media.Geometry.Parse(all_comand);
                colection.Add(path);

                Names nam = new Names(path.Name, "Path", color11, color22, all_comand, path.StrokeThickness);
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
