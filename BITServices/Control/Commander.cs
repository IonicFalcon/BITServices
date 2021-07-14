using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BITServices.Control
{
    public class Commander : ICommand
    {
         private Action whatToExecute;
         public event EventHandler CanExecuteChanged;
          

         public Commander(Action what)
         {
             this.whatToExecute = what;
         }

         public bool CanExecute(object parameter) 
         {
             return true;
         }

         public void Execute(object parameter)
         {
             whatToExecute.Invoke();
         }
        
    }
}
