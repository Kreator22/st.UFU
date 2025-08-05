using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.Model.Equations
{
    /// <summary>
    /// Интерфейс уравнения f(x)
    /// </summary>
    public interface IEquation
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Описание для пользователя
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Уравнение
        /// </summary>
        Func<double, double> F_x { get; }
    }
}
