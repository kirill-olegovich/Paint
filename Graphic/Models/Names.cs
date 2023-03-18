namespace Paint.Models
{
	public class Names
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public string StartPoint { get; set; }
		public string EndPoint { get; set; }
		public string Points { get; set; }
		public double Thickes { get; set; }
		public string ColorStr { get; set; }
		public string ColorFill { get; set; }
		public double Width { get; set; }
		public double Height { get; set; }

		//public Names() { }

		public Names(string nam, string type, string start, string end, double thic, string str)
		{
			Name = nam;
            Type = type;
            StartPoint = start;
			EndPoint = end;
			Thickes = thic;
            ColorStr = str;
		}

		public Names(string nam, string type, string point, double thic, string str)
		{
			Name = nam;
            Type = type;
            Points = point;
			Thickes = thic;
            ColorStr = str;
		}

        public Names(string name, string type, string str, string fill, string temp_all_point, double strokeThickness)
        {
            Name = name;
            Type = type;
            ColorStr = str;
            ColorFill = fill;
            Points = temp_all_point;
            Thickes = strokeThickness;
        }

        public Names(string name, string type, string str, string fill, double strokeThickness, double width, double height)
		{
			Name = name;
            Type = type;
            ColorStr = str;
            ColorFill = fill;
			Thickes = strokeThickness;
			Width = width;
			Height = height;
		}
	}
}
