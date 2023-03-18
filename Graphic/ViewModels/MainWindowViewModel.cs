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
		private ViewModelBase[] contentColection;
		private ObservableCollection<Names> figuresName;
		private ViewModelBase curentContent;
		private MainWindow mainWindow;
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

			Line line = new Line();
			line.StartPoint = new Avalonia.Point(10, 10);
			line.EndPoint = new Avalonia.Point(100, 10);
			line.Name = "lin";
			line.Stroke = SolidColorBrush.Parse("Blue");
			line.StrokeThickness = 1;
			figuresColection.Add(line);
			Names nev = new Names(line.Name, "line", "10,10", "100,10", line.StrokeThickness, "blue");
			figuresName.Add(nev);


			DeleteBut = ReactiveCommand.Create(() =>
			{
				figuresColection.RemoveAt(Listbox_index);
				figuresName.RemoveAt(Listbox_index);
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

		public ObservableCollection<Names> Figures_name
		{
			get => figuresName;
			set
			{
				this.RaiseAndSetIfChanged(ref figuresName, value);
			}
		}

		public ReactiveCommand<Unit, Unit> DeleteBut { get; }

		public ObservableCollection<Shape> Figures_colection
		{
			get => figuresColection;
			set
			{
				this.RaiseAndSetIfChanged(ref figuresColection, value);
			}
		}

		public int Listbox_index
		{
			get => listboxIndex;
			set
			{
				this.RaiseAndSetIfChanged(ref listboxIndex, value);
			}
		}

		public ViewModelBase Content_colection
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
				Content_colection = contentColection[value];
			}
		}
	}
}