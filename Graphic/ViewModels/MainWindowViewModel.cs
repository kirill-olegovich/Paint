using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Paint.Models;
using Paint.ViewModels.Pages;
using Paint.Views;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Paint.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		private int listboxIndex = 0;
		private int comboboxIndex = 0;
		private int countFigure = 0;
		private ObservableCollection<Shape> figuresColection;
        private ViewModelBase curentContent;
        private MainWindow mainWindow;
        private ViewModelBase[] contentColection;
		private ObservableCollection<Names> figuresName;
		private Canvas canvas;

		public MainWindowViewModel(MainWindow mw)
		{
			mainWindow = mw;
			canvas = mainWindow.Find<Canvas>("canvas");
			figuresColection = new ObservableCollection<Shape>();
			figuresName = new ObservableCollection<Names>();

			contentColection = new ViewModelBase[]
			{
				new LineViewModel(ref figuresColection, ref figuresName),
				new PolyLineViewModel(ref figuresColection, ref figuresName),
				new PolygonViewModel(ref figuresColection, ref figuresName),
				new RectangleViewModel(ref figuresColection, ref figuresName),
				new EllipseViewModel(ref figuresColection, ref figuresName),
				new PathViewModel(ref figuresColection, ref figuresName)
			};

			curentContent = contentColection[0];

			Line _line = new Line();
            _line.StartPoint = new Avalonia.Point(10, 10);
            _line.EndPoint = new Avalonia.Point(100, 10);
            _line.Name = "lin";
            _line.Stroke = SolidColorBrush.Parse("Blue");
            _line.StrokeThickness = 1;
			figuresColection.Add(_line);
			Names nev = new Names(_line.Name, "line", "10,10", "100,100", _line.StrokeThickness, "black");
			figuresName.Add(nev);


			DeleteBut = ReactiveCommand.Create(() =>
			{
				figuresColection.RemoveAt(ListboxIndex);
				figuresName.RemoveAt(ListboxIndex);
			});
		}

		static string Convert(object classObject)
		{
			string xmlString = null;
			XmlSerializer xmlSerializer = new XmlSerializer(classObject.GetType());
			using (MemoryStream memoryStream = new MemoryStream())
			{
				xmlSerializer.Serialize(memoryStream, classObject);
				memoryStream.Position = 0;
				xmlString = new StreamReader(memoryStream).ReadToEnd();
			}
			return xmlString;
		}
		public async void SaveXML()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			string? result = await saveFileDialog.ShowAsync(mainWindow);
			string xmlstring = Convert(figuresName);
			XElement xElement = XElement.Parse(xmlstring);
			xElement.Save(result);
		}

		public ReactiveCommand<Unit, Unit> DeleteBut { get; }

        public ObservableCollection<Names> Figures_name
        {
            get => figuresName;
            set
            {
                this.RaiseAndSetIfChanged(ref figuresName, value);
            }
        }
        
		public ObservableCollection<Shape> Figures_colection
		{
			get => figuresColection;
			set
			{
				this.RaiseAndSetIfChanged(ref figuresColection, value);
			}
		}

		public int ListboxIndex
        {
			get => listboxIndex;
			set
			{
				this.RaiseAndSetIfChanged(ref listboxIndex, value);
			}
		}

		public ViewModelBase ContentColection
		{
			get => curentContent;
			set
			{
				this.RaiseAndSetIfChanged(ref curentContent, value);
			}
		}
		public int Combobox_index
		{
			get => comboboxIndex;
			set
			{
				comboboxIndex = value;
                ContentColection = contentColection[value];
			}
		}
	}
}