using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApplication1.metodos
{
    public class limpiar
    {
        public static void LimpiarCampos(Control control) {
            foreach(var txt in control.Controls){
                if(txt is TextBox){
                    ((TextBox)txt).Clear();
                }
                else if(txt is ComboBox){
                    ((ComboBox)txt).SelectedIndex = 0 ;
                }
            }
        }
    }
}
