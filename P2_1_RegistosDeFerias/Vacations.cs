using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P00_Utility;

namespace P2_1_RegistosDeFerias
{
    internal class Vacations
    {
        
        #region Properties 
        internal string UserName { get; set; }
        internal DateTime DataInicio { get; set; }
        internal DateTime DataFim { get; set; }
        #endregion

        #region Constructors 
        internal Vacations(string userName, DateTime inico, DateTime fim)
        {
            UserName = userName;
            DataInicio = inico;
            DataFim = fim;
        }
        #endregion


        #region Methods
        internal string Format()
        {
            return $"{UserName}: {DataInicio:dd/MM/yyy} - {DataFim:dd/MM/yyyy}\n";
        } 
       

        #endregion
    }
}