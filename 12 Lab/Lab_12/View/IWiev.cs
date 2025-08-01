using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12.View
{
    // общие методы для всех представлений
    public interface IView
    {
        void Show();
        void Close();
    }
}
