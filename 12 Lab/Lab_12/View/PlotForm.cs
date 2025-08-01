using Lab_12.View;
using System.Runtime.InteropServices;

namespace Lab_12
{
    public partial class PlotForm : Form, IPlotFormView
    {
        private PlotUserInput userInput;

        public event EventHandler<PlotUserInput> SolveTheEquation;

        public PlotForm()
        {
            userInput = new("", "", "", "", "");
            InitializeComponent();
        }

        public new void Show() =>
            Application.Run(this);






        #region Заполнение ComboBox
        public void AddSolverMethods(IEnumerable<(string name, string description)> solvers) =>
            AddStringsToComboBox(SolveMethod, solvers);

        public void AddEquations(IEnumerable<(string name, string description)> equations) =>
            AddStringsToComboBox(Equation, equations);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="box">Элемент <see cref="ComboBox"/></param>
        /// <param name="strings">description - отображается для пользователя, name - выступает ключом</param>
        /// <remarks>
        /// Определенно нарушаем принцип единой ответственности
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

        private void SolveTheEquation_Click(object sender, EventArgs e)
        {
            //Значение Epsilon по умолчанию не будет обработано событием epsilon_TextChanged
            //если пользователь не захочет его изменять
            userInput.Epsilon = epsilon.Text;
            SolveTheEquation(this, userInput);
        }
            
            
    }
}
