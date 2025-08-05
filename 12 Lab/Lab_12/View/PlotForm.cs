using Lab_12.View;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab_12
{
    public partial class PlotForm : Form, IPlotFormView
    {
        private PlotUserInput userInput;

        public event EventHandler<PlotUserInput> SolveTheEquation;
        public event EventHandler PlotResults;

        public PlotForm()
        {
            userInput = new("", "", "", "", "");
            InitializeComponent();
        }

        public new void Show() =>
            Application.Run(this);


        #region Заполнение ComboBox представителем
        public void AddSolverMethods(IEnumerable<(string name, string description)> solvers) =>
            AddStringsToComboBox(SolveMethod, solvers);

        public void AddEquations(IEnumerable<(string name, string description)> equations) =>
            AddStringsToComboBox(Equation, equations);

        /// <summary>
        /// Добавление строк в любой ComboBox, настройка его ширины и поведения
        /// </summary>
        /// <param name="box">Элемент <see cref="ComboBox"/></param>
        /// <param name="strings">description - отображается для пользователя, name - выступает ключом</param>
        /// <remarks>
        /// Нарушаем принцип единой ответственности?
        /// </remarks>
        private void AddStringsToComboBox(ComboBox box, IEnumerable<(string name, string description)> strings)
        {
            var _strings = strings.Select(s => new { Name = s.name, Description = s.description }).ToList();
            box.DisplayMember = "Description";
            box.ValueMember = "Name";
            box.DataSource = _strings;

            //Запрещаем пользователю вводить что-либо
            box.DropDownStyle = ComboBoxStyle.DropDownList;

            //Устанавливаем ширину выпдающего списка равной ширине самой высокой строки
            string d = strings.MaxBy(s => s.description.Length).description;
            Graphics g = this.CreateGraphics();
            box.DropDownWidth = (int)g.MeasureString(d, SolveMethod.Font).Width;
        }
        #endregion

        #region Данные и события для представителя
        public PlotUserInput GetUserInputData() => userInput;
        private void SolveMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            object? value = SolveMethod.SelectedValue;
            if (value is not null)
                userInput.SolverMethod = value.ToString()!;
        }

        private void Equation_SelectedIndexChanged(object sender, EventArgs e)
        {
            object? value = Equation.SelectedValue;
            if (value is not null)
                userInput.Equation = value.ToString()!;
        }

        private void leftBoundary_TextChanged(object sender, EventArgs e) =>
            userInput.LeftBoundary = leftBoundary.Text;

        private void rightBoundary_TextChanged(object sender, EventArgs e) =>
            userInput.RightBoundary = rightBoundary.Text;

        private void epsilon_TextChanged(object sender, EventArgs e) =>
            userInput.Epsilon = epsilon.Text;

        private void SolveTheEquation_btn_Click(object sender, EventArgs e)
        {
            //Значение Epsilon по умолчанию не будет обработано событием epsilon_TextChanged
            //если пользователь не захочет его изменять
            userInput.Epsilon = epsilon.Text;
            SolveTheEquation(this, userInput);
        }

        private void PlotTheEquation_btn_Click(object sender, EventArgs e) =>
            PlotResults(this, e);
        #endregion

        #region Методы для представителя
        public void ShowError(string errorText, string errorCaption = "Ошибка") =>
            MessageBox.Show(errorText, errorCaption);

        public void PrintSolution(double solution, int iterations)
        {
            this.solution.Text = solution.ToString();
            this.iterations.Text = iterations.ToString();
        }
        public void PlotGraph(IEnumerable<(double X, double Y)> points)
        {
            Plot.Series.Clear();
            var series = new Series
            {
                ChartType = SeriesChartType.Spline,
                Color = Color.Red,
                BorderWidth = 3,
                LegendText = "График уравнения",
            };
            Plot.Series.Add(series);

            foreach (var point in points)
                series.Points.AddXY(point.X, point.Y);

            double minX = series.Points[0].XValue;
            double maxX = series.Points[series.Points.Count - 1].XValue;
            double interval = 1;
            string format = "N1";

            //TODO : переделать отображение оси так, чтобы для любого
            //диапазона она билась на +-n равных частей с красивыми числами на оси
            switch (maxX - minX)
            {
                case <= 0.1:
                    minX = double.Round(minX, 2, MidpointRounding.ToNegativeInfinity);
                    maxX = double.Round(maxX, 2, MidpointRounding.ToPositiveInfinity);
                    interval = 0.01;
                    format = "N3";
                    break;
                case > 0.1 and <= 1:
                    minX = double.Round(minX, 1, MidpointRounding.ToNegativeInfinity);
                    maxX = double.Round(maxX, 1, MidpointRounding.ToPositiveInfinity);
                    interval = 0.1;
                    format = "N2";
                    break;
                case > 1 and <= 10:
                    minX = double.Round(minX, 0, MidpointRounding.ToNegativeInfinity);
                    maxX = double.Round(maxX, 0, MidpointRounding.ToPositiveInfinity);
                    interval = 1;
                    format = "N1";
                    break;
                case > 10 and < 100:
                    minX = double.Round(minX, 0, MidpointRounding.ToNegativeInfinity);
                    maxX = double.Round(maxX, 0, MidpointRounding.ToPositiveInfinity);
                    interval = 10;
                    format = "N";
                    break;
            }

            Plot.ChartAreas[0].AxisX.Minimum = minX;
            Plot.ChartAreas[0].AxisX.Maximum = maxX;
            Plot.ChartAreas[0].AxisX.Interval = interval;
            Plot.ChartAreas[0].AxisX.LabelStyle.Format = format;
        }

        public void PlotSolution(IEnumerable<(double X, double Y, int number)> solutions)
        {
            var series = new Series
            {
                ChartType = SeriesChartType.Point,
                Color = Color.Black,
                IsVisibleInLegend = true,
                LegendText = "Итерации решения",
                MarkerColor = Color.Blue
            };
            Plot.Series.Add(series);

            int i = 0;
            foreach (var solution in solutions)
            {
                series.Points.AddXY(solution.X, solution.Y);
                series.Points[i].LabelToolTip = $"Y{solution.number} = {solution.Y}";
                series.Points[i++].Label = $"X{solution.number} = {solution.X}";
            }
        }
        #endregion
    }
}
