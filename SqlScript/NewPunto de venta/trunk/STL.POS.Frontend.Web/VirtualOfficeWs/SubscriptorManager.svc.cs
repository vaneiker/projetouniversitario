using STL.POS.Data;
using STL.POS.Frontend.Web.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace STL.POS.Frontend.Web.VirtualOfficeWs
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SubscriptorManager" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SubscriptorManager.svc or SubscriptorManager.svc.cs at the Solution Explorer and start debugging.
    public class SubscriptorManager : ISubscriptorManager
    {

        PosModel dataAccess;

        private const string USER_ACTUALIZADOR = "Actualizador Virtual Office Users";
        private const string USER_LOG_TITLE_ERROR = "Error en actualización de usuario";

        private static Mutex mut = new Mutex();

        public SubscriptorManager(PosModel da)
        {
            dataAccess = da;
        }

        public List<Result> ContingencyOperation(List<User> users)
        {
            var resultList = new ConcurrentBag<Result>();

            //Just to keep ordering, first the subscriptors
            var subscriptors = new List<User>();
            subscriptors.AddRange(users.Where(u => !u.SubscriptorId.HasValue));
            var agents = new List<User>();
            agents.AddRange(users.Where(u => u.SubscriptorId.HasValue));

            Parallel.ForEach(subscriptors, u =>
            {
                resultList.Add(CreateOrUpdateUser(u));
            });
            Parallel.ForEach(agents, u =>
            {
                resultList.Add(CreateOrUpdateUser(u));
            });

            return resultList.ToList();
        }

        public Result CreateOrUpdateUser(User user)
        {
            var result = new Result();
            result.Status = true;
            result.UserId = user.Id;
            switch (user.Operacion)
            {
                case Operacion.Alta:
                    {
                        var posUser = user.GetPosUser();

                        if (user.SubscriptorId.HasValue)
                        {
                            var suscriptor = dataAccess.Users.FirstOrDefault(u => u.UserType == UserType.Subscriptor && u.VirtualOfficeId == user.Id);
                            if (suscriptor == null)
                            {
                                result.Status = false;
                                result.StatusMessage = "El agente ingresado tiene un suscriptor que aún no ha sido agregado all sistema. Agregue el suscriptor y luego el agente.";
                                LoggerHelper.Log(Categories.Error, USER_ACTUALIZADOR, 0, USER_LOG_TITLE_ERROR, result.StatusMessage + "\n" + user.ToString());
                            }
                            else
                            {
                                posUser.Suscriptor = suscriptor;
                                dataAccess.Users.Add(posUser);
                            }
                        }
                        else
                        {
                            dataAccess.Users.Add(posUser);
                        }
                        break;
                    };
                case Operacion.Modificacion:
                    {
                        var dbUser = dataAccess.Users.FirstOrDefault(u => u.VirtualOfficeId == user.Id);

                        if (dbUser == null)
                        {
                            result.Status = false;
                            result.StatusMessage = "El usuario ingresado no existe en Punto de Venta. Considere crearlo nuevamente (operación Alta).";
                            LoggerHelper.Log(Categories.Error, USER_ACTUALIZADOR, 0, USER_LOG_TITLE_ERROR, result.StatusMessage + "\n" + user.ToString());
                        }
                        else
                        {
                            user.SetUserData(dbUser);

                            if (user.SubscriptorId.HasValue)
                            {

                                var suscriptor = dataAccess.Users.FirstOrDefault(u => u.UserType == UserType.Subscriptor && u.VirtualOfficeId == user.Id);
                                if (suscriptor == null)
                                {
                                    result.Status = false;
                                    result.StatusMessage = "El agente ingresado tiene un suscriptor que aún no ha sido agregado all sistema. Agregue el suscriptor y luego el agente.";
                                    LoggerHelper.Log(Categories.Error, USER_ACTUALIZADOR, 0, USER_LOG_TITLE_ERROR, result.StatusMessage + "\n" + user.ToString());
                                }
                                else
                                {
                                    dbUser.Suscriptor = suscriptor;
                                    dataAccess.Users.Add(dbUser);
                                }
                            }
                            else
                            {
                                dataAccess.Users.Add(dbUser);
                            }
                        }
                        break;
                    };
                case Operacion.Baja:
                    {
                        var dbUser = dataAccess.Users.FirstOrDefault(u => u.VirtualOfficeId == user.Id);

                        if (dbUser == null)
                        {
                            result.Status = false;
                            result.StatusMessage = "El usuario ingresado no existe en Punto de Venta.";
                            LoggerHelper.Log(Categories.Error, USER_ACTUALIZADOR, 0, USER_LOG_TITLE_ERROR, result.StatusMessage + "\n" + user.ToString());
                        }
                        else
                        {
                            dataAccess.Users.Remove(dbUser);
                        }
                        break;
                    };
            }

            mut.WaitOne();
            try
            {
                if (result.Status)
                    dataAccess.SaveChanges();
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(Categories.Error, USER_ACTUALIZADOR, 0,
                    USER_LOG_TITLE_ERROR,
                    "Se produjo un error al agregar un usuario desde Virtual Office.\nMensaje: " + ex.Message + "\nDetalle: " + ex.StackTrace, ex);
                result.Status = false;
                result.StatusMessage = "Se produjo un error al agregar un usuario desde Virtual Office.\nMensaje: " + ex.Message + "\nDetalle: " + ex.StackTrace;
            }

            mut.ReleaseMutex();

            return result;
        }

    }
}
