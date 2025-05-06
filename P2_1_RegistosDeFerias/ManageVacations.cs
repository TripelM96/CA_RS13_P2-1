using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P00_Utility;

namespace P2_1_RegistosDeFerias
{
    internal class ManageVacations
    {
        #region Methods
        private ArrayList list = new ArrayList();
        internal void Register(User user, DateTime inicio, DateTime fim)
        {          

            if (fim < inicio)
            {
                Utility.WriteErrorMessage("Erro: Data de fim anterior à data de início");
                return;
            }

            foreach (Vacations f in list)
            {
                if (f.UserName == user.Name && ((inicio >= f.DataInicio && inicio <= f.DataFim) || (fim >= f.DataInicio && fim <= f.DataFim))) // Verifica sobreposição de datas
                {
                    Utility.WriteErrorMessage("Erro: Sobreposição de datas.");
                    return;
                }
            }
            list.Add(new Vacations(user.Name, inicio, fim));
            Utility.WriteAproveMessage("Férias adicionadas com sucesso","\n","");
        }
        internal void List(User user)
        {
            Utility.WriteTitle("Lista de Férias");

            foreach (Vacations f in list)
            {
                if (user.PermissionManageVac(f.UserName))
                {
                    Utility.WriteMessage(f.Format());
                }
            }

            if (list.Count == 0)
            {
                Utility.WriteErrorMessage("Não existe registos para listar.","\n","");
            }

        }
        internal void Consulting(User user, DateTime inicio, DateTime fim)
        {           
            foreach (Vacations f in list)
            {
                if(user.PermissionManageVac(f.UserName) && (f.DataInicio >= inicio && f.DataFim <= fim))
                {
                    Utility.WriteMessage(f.Format(), "\n", "");
                }
            }

            if (list.Count == 0)
            {
                Utility.WriteErrorMessage("Não existem registos para consultar.", "\n", "");
            }
        }
        internal void Update(User user, int index, DateTime novoInicio, DateTime novoFim)
        {
            if (index < 0 || index >= list.Count)
            {
                Utility.WriteErrorMessage("Índice inválido.");
                return;
            }            

            /*
                    Como "list" é um ArrayList, uma colletion onde os itens são armazenados como objetos

                        ArrayList list = new ArrayList();
                        list.Add(new Vacations (...))

                    Quando faço "list[index]" estou aceder a um elemento no indice indicado como se fosse um array normal
                    Como ArrayList não é genérica, os intens sao tratados como obejtos, Para aceder as propriedades especificas da classe Vacations, tem que se fazer um Cast
            */
            Vacations f = (Vacations)list[index];

            if (!user.PermissionManageVac(f.UserName))
            {
                Utility.WriteErrorMessage("Sem premissão");
            }

            f.DataInicio = novoInicio;
            f.DataFim = novoFim;
            Utility.WriteAproveMessage("Férias atualizadas com sucesso.","\n","");
        }      

        internal void ListIndex(User user)
        {            
            for (int i = 0; i < list.Count; i++)
            {
                Vacations
                    f = (Vacations)list[i];
                if (user.PermissionManageVac(f.UserName))
                {
                    Utility.WriteMessage($"{i}: {f.Format()}");
                    
                }
            }
           
        }
        internal bool IsEmpty(User user)
            
        {
            foreach (Vacations f in list)
            {
                if (user.PermissionManageVac(f.UserName))
                    return false;
            }
            return true;
        }

        #endregion
    }
}
