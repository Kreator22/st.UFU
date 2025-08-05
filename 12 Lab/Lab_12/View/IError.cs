using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.View
{
    /// <summary>
    /// Интерфейс для объектов, которые умеют отображать ошибки
    /// </summary>
    public interface IError
    {
        /// <summary>
        /// Отображение ошибки
        /// </summary>
        /// <param name="errorText">Текст ошибки</param>
        /// <param name="errorCaption">Заголовок окна ошибки</param>
        void ShowError(string errorText, string errorCaption);
    }
}
