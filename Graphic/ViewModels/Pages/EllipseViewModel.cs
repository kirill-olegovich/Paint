using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Paint.Models;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace Paint.ViewModels.Pages
{
    public class EllipseViewModel : ViewModelBase
    {
        private ObservableCollection<Shape> colection;
        private ObservableCollection<Names> nam_colection;
        private string name = string.Empty, points = string.Empty;
        private int thic = 1, select1 = 0, select2 = 0, wid = 0, hei = 0;
        public EllipseViewModel(ref ObservableCollection<Shape> colec, ref ObservableCollection<Names> nam)
        {
            colection = colec;
            nam_colection = nam;
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

        public int Wid
        {
            get => wid;
            set
            {
                this.RaiseAndSetIfChanged(ref wid, value);
            }
        }

        public int Hei
        {
            get => hei;
            set
            {
                this.RaiseAndSetIfChanged(ref hei, value);
            }
        }

        // function
        public void Button_add()
        {
            if (Points != null && Name != null)
            {
                Avalonia.Point point = Point.Parse(Points);
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


                Avalonia.Controls.Shapes.Ellipse elipse = new Avalonia.Controls.Shapes.Ellipse();
                elipse.Name = Name;
                elipse.Width = Wid;
                elipse.Height = Hei;
                elipse.StrokeThickness = Thic;
                elipse.Stroke = color1;
                elipse.Fill = color2;
                colection.Add(elipse);

                Names nam = new Names(elipse.Name, "elipse", color11, color22, elipse.StrokeThickness, elipse.Width, elipse.Height);
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
